import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Property } from '../models/property';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  constructor(private http: HttpClient) { }

  create(description: string, categoryId: string, addressId: string, photos: File[]): Observable<Property> {
    var data = new FormData();
    data.append('description', description);
    data.append('categoryId', categoryId);
    data.append('addressId', addressId);

    for(let i = 0; i < photos.length; i++) {
      data.append('photos', photos[i]);
    } 

    return this.http.post<Property>(`${apiUrl}/properties`, data);
  }
}
