import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category'
import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  loadCategories() : Observable<Category[]> {
    return this.http.get<Category[]>(`${apiUrl}/categories`);
  }

  getCategory(id: string) : Observable<Category> {
    return this.http.get<Category>(`${apiUrl}/categories/${id}`);
  }

  create(input: {name: string}) : Observable<any> {
    return this.http.post(`${apiUrl}/categories`, input);
  }

  edit(category: Category) : Observable<any> {
    console.log(category);
    return this.http.put(`${apiUrl}/categories/${category.id}`, { name: category.name })
  }

  delete(id: string) : Observable<any> {
    return this.http.delete(`${apiUrl}/categories/${id}`);
  }

  checkName(name: string) : Observable<boolean> {
    const params = new HttpParams().set('name', name)
    return this.http.get<boolean>(`${apiUrl}/categories/checkIfNameIsTaken`, {params: params});
  }
}
