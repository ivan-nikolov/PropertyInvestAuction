import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { DecodedToken } from '../models/decodedToken';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  constructor() { }

  decodeToken(token: string): DecodedToken {
    return jwtDecode(token);
  }
}
