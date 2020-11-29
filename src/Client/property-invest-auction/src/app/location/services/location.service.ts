import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Country } from '../models/country';
import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
const controllerName = 'countries';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http: HttpClient) { }

  loadCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(`${apiUrl}/${controllerName}/all`);
  }

}
