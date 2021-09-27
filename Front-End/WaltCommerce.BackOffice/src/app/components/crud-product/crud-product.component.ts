import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product/product.service';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-crud-product',
  templateUrl: './crud-product.component.html',
  styleUrls: ['./crud-product.component.scss']
})
export class CrudProductComponent implements OnInit {
  ProductList: any[] = []
  closeModal: string;
  constructor(private _productService: ProductService,
              private modalService: NgbModal) { }

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

  openModal(content) {
    this.modalService.open(content, {size:'xl',ariaLabelledBy: 'modal-basic-title'}).result.then((res) => {
      this.closeModal = `Closed with: ${res}`;
    }, (res) => {
      this.closeModal = `Dismissed ${this.getDismissReason(res)}`;
    });
  }
  
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

}
