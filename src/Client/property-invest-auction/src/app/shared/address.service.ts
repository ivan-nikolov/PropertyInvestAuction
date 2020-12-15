import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Address } from './address-select/address';
import { environment } from '../../environments/environment';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient) { }

  loadAddresses(cityId: string, neighborhoodId: string) : Observable<Address[]> {

    const params = new HttpParams({fromObject: {cityId: cityId, neighborhoodId: neighborhoodId}});

    return this.http.get<Address[]>(`${apiUrl}/addresses`, {params: params});
  }

  create(address: string, cityId: string, neighborhoodId: string): Observable<Address> {
    return this.http.post<Address>(`${apiUrl}/addresses`, {name: address, cityId: cityId, neighborhoodId: neighborhoodId});
  }

  validateId(id: string): Observable<boolean> {
    return this.http.get<boolean>(`${apiUrl}/addresses/${id}`);
  }
}
