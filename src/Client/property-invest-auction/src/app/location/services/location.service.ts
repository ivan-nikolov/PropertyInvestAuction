import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Country } from '../models/country';
import { environment } from '../../../environments/environment';
import { City } from '../models/city';
import { Neighborhood } from '../models/neighborhood';
import { CityInput } from '../models/city-input';
import { NeighborhoodInput } from '../models/neighborhood-input';

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

  loadNeighborhoods (cityId: string) : Observable<Neighborhood[]> {
    var params = new HttpParams().set('cityId', cityId);
    return this.http.get<Neighborhood[]>(apiUrl + '/neighborhoods/getByCityId', {params: params});
  }

  addCountry(name: string) : Observable<any> {
    return this.http.post(apiUrl + '/countries/create', name);
  }

  addCity(data: CityInput) : Observable<any> {
    return this.http.post(apiUrl + '/cities/create', data);
  }

  addNeighborhood(data: NeighborhoodInput) : Observable<any> {
    return this.http.post(apiUrl + '/neighborhoods/create', data);
  }

  checkCountryName(countryName: string) : Observable<boolean> {

    const params = new HttpParams().set('name', countryName);
    
    return this.http.get<boolean>(apiUrl + '/countries/checkCountryName', {params: params});

  }

  checkCityName(countryId: string, cityName: string) : Observable<boolean> {
    const params = new HttpParams({fromObject: {countryId: countryId, name: cityName}});
    
    return this.http.get<boolean>(apiUrl + '/cities/checkCityName', {params: params});
  }

  checkNeighborhoodName(cityId: string, name: string) : Observable<boolean> {
    const params = new HttpParams({fromObject: { cityId: cityId, name: name}});

    return this.http.get<boolean>(apiUrl + '/neighborhoods/checkName', {params: params});
  }
}
