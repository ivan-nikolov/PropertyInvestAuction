import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { RegisterInputModel } from '../models/registerInputModel';
import { LoginInputModel } from '../models/loginInputModel';
import { LoginResponseModel } from '../models/loginResponseModel';
import { JwtService } from './jwt.service';
import { User } from '../models/user';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private jwtService: JwtService) { }

  all(page: number, pageSize: number, query: string): Observable<User[]> {
    return this.http.get<User[]>(`${apiUrl}/identity/GetPage?page=${page}&pageSize=${pageSize}&query=${query}`);
  }

  getCount(): Observable<number>{
    return this.http.get<number>(apiUrl + '/identity');
  }

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

    return new Array();
  }

  isAuthenticated() {
    if(this.getUserToken()){
      return true;
    }

    return false;
  }

  addToAdmin(id: string): Observable<any> {
    return this.http.post(apiUrl + '/identity/addToAdmin', {id});
  }

  removeFromAdmin(id: string): Observable<any> {
    return this.http.post(apiUrl + '/identity/removeFromAdmin', { id });
  }
}
