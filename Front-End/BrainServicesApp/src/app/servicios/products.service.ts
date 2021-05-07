import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { environment } from 'src/environments/environment'

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private appUrl = environment.baseUrl
  private apiUrl = 'api/Product'

  constructor(private http: HttpClient) {}

  getListProducts(): Observable<any> {
    return this.http.get(this.appUrl + this.apiUrl)
  }
}
