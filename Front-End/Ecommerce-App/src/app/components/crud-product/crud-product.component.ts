import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-crud-product',
  templateUrl: './crud-product.component.html',
  styleUrls: ['./crud-product.component.scss']
})
export class CrudProductComponent implements OnInit {
  ProductList: any[] = []
  constructor(private _productService: ProductService) { }

  ngOnInit(): void {
    this.getListProduct();
  }

  getListProduct() {
    this._productService.getListProducts().subscribe(
      data => {
        this.ProductList = data
      },
      error => {
        console.log(error)
      },
    )
  }

}
