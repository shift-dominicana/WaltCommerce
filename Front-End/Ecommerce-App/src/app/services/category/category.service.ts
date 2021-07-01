import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { from, Observable } from 'rxjs'
import { environment } from 'src/environments/environment'
import {Category} from 'src/app/models/Category'


@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private appUrl = environment.baseUrl
  private apiUrl = 'api/ProductCategory'
  
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  

  selectedCategory: Category = new Category();

  constructor(private http: HttpClient) { }

  getCategories(): Observable<any>{
    return this.http.get(this.appUrl+this.apiUrl)
  }

  update(data: any): Observable<any> {
    return this.http.put(this.appUrl+this.apiUrl, data);
  }

  create(data: any): Observable<any> {
    return this.http.post(this.appUrl+this.apiUrl, data, this.httpOptions);
  }

  delete(id: any): Observable<any> {
    return  this.http.delete(this.appUrl+this.apiUrl+'/'+id);
  }
}
