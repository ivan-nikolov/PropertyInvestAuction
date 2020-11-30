import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Country } from '../models/country';
import { environment } from '../../../environments/environment';
import { City } from '../models/city';

const apiUrl = environment.apiUrl;
const controllerName = 'countries';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http: HttpClient) { }

  loadCountries (): Observable<Country[]> {
    return this.http.get<Country[]>(`${apiUrl}/${controllerName}/all`);
  }

  loadCitiesByCountryId (countryId: string): Observable<City[]> {
    var params = new HttpParams().set('countryId', countryId);
    return this.http.get<City[]>(`${apiUrl}/cities`,{params: params });
  }
}
