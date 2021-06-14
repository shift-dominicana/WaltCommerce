import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { environment } from 'src/environments/environment'
import {Category} from 'src/app/models/Category'

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private appUrl = environment.baseUrl
  private apiUrl = 'api/ProductCategory'
  selectedCategory: Category = new Category();

  constructor(private http: HttpClient) { }

  getCategories(): Observable<any>{
    return this.http.get(this.appUrl+this.apiUrl)
  }

  update(data: any): Observable<any> {
    return this.http.put(this.appUrl+this.apiUrl, data);
  }
}
