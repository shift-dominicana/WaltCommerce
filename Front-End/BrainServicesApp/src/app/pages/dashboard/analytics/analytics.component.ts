import { Component, OnInit } from '@angular/core'
import { ProductsService } from 'src/app/servicios/products.service'

@Component({
  selector: 'app-dashboard-analytics',
  templateUrl: './analytics.component.html',
})
export class DashboardAnalyticsComponent implements OnInit {
  listProducts: any[] = []
  constructor(private _productService: ProductsService) {}
  ngOnInit() {
    this.getListProduct()
  }

  getListProduct() {
    this._productService.getListProducts().subscribe(
      data => {
        this.listProducts = data
      },
      error => {
        console.log(error)
      },
    )
  }
}
