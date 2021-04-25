import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private appUrl = 'https://192.168.0.110:5001/'
  private apiUrl = 'api/Product'

  constructor(private http: HttpClient) {}

  getListProducts(): Observable<any> {
    return this.http.get(this.appUrl + this.apiUrl)
  }
}
