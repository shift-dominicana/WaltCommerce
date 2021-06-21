import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { environment } from 'src/environments/environment'
import {Category} from 'src/app/models/Category'



const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'}),
};

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

  create(data: any): Observable<any> {
    return this.http.post(this.appUrl+this.apiUrl, data, httpOptions);
  }
}
