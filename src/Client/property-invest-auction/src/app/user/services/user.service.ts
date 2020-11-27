import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { RegisterInputModel } from '../models/registerInputModel';
import { LoginInputModel } from '../models/loginInputModel';
import { LoginResponseModel } from '../models/loginResponseModel';
import { JwtService } from './jwt.service';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private jwtService: JwtService) { }

  login(data: LoginInputModel) : Observable<LoginResponseModel> {
    return this.http.post<LoginResponseModel>(apiUrl + '/identity/login', data);
  }

  register(data: RegisterInputModel) : Observable<any> {
    return this.http.post(apiUrl + '/identity/register', data);
  }

  logout(){
    if(this.isAuthenticated()) {
      this.removeUserData();
    }
  }

  setUserData(data: LoginResponseModel) {
    localStorage.setItem('token', data.token);
  }

  removeUserData() {
    localStorage.removeItem('token');
  }

  //TODO: Implement Refresh Token
  getUserToken(): string{
    var token = localStorage.getItem('token');
    if(token) {
      var decToken = this.jwtService.decodeToken(token);
      if(Date.now() < decToken.exp * 1000){
        return token;
      }

      this.removeUserData();
    }

    return '';
  }

  getRoles(): string[]{
    var token = this.getUserToken();
    if (token) {
      var decodedToken = this.jwtService.decodeToken(token);
      return decodedToken.roles;
    }
  }

  isAuthenticated() {
    if(this.getUserToken()){
      return true;
    }

    return false;
  }
}
