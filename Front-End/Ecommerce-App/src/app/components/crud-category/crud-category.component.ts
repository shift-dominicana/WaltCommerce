import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category/category.service';
import {ModalDismissReasons, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import { Category } from 'src/app/models/Category';
import { FormGroup, FormBuilder, NgForm } from '@angular/forms';

@Component({
  selector: 'app-crud-category',
  templateUrl: './crud-category.component.html',
  styleUrls: ['./crud-category.component.scss']
})
export class CrudCategoryComponent implements OnInit {
  CategoryList: any[] = []
  closeModal: string;
  editProfileForm: FormGroup;
  addProfileForm: FormGroup
  message: string;
  closeResult: string;
  constructor(
    private fb: FormBuilder,
    public categoryService: CategoryService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.getCategories();

    this.editProfileForm = this.fb.group({
      id: [''],
      identificator: [''],
      description: ['']
    });
    this.addProfileForm = this.fb.group({
      id: [''],
      identificator: [''],
      description: ['']
    })
  }

  getCategories() {
    this.categoryService.getCategories().subscribe(
      data => {
        this.CategoryList = data
      },
      error => {
        console.log(error)
      },
    )
  }

  updateCategory(category: Category){
    this.categoryService.update(category).subscribe(
      response =>{
        console.log(response);
        this.message = response.message ? response.message : 'This category was updated successfully!';
      },
      error =>{
        console.log(error);
      }
    );
  }

  openAddModal(content) {
    this.modalService.open(content)
  }

  openModal(content, category) {
    
    this.modalService.open(content, {
      centered: true,
      backdrop: 'static',
      size:'xl',
      ariaLabelledBy: 'modal-basic-title'
    })
      .result.then((result) => {
        this.closeResult = `Closed with: ${result}`
        window.location.reload()
      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`
        window.location.reload()
      })
    
    if (this.categoryService.selectedCategory.Id === null) {
      //console.log("New")
      //this.openModal(this.addProfileForm, Category)
      this.editProfileForm.patchValue({
        id: 0,
        identificator: "",
        description: ""
      });
    }
    else {
      //this.onSubmit()
      this.editProfileForm.patchValue({
        id: category.id,
        identificator: category.identificator,
        description: category.description
      });
    }
  }

  newCategory = {
    id: 0,
    identificator: "",
    descripton: ""
  }

  addCategory() {
    console.log("Klk", this.addProfileForm.value)
    this.modalService.dismissAll();
    window.location.reload()
  }
  
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
      //window.location.reload()
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
      //window.location.reload()
    } else {
      return `with: ${reason}`;
      //window.location.reload()
    }
  }

  onSaveCategory() {
    if (this.categoryService.selectedCategory.Id === null) {
      //console.log("New")
      this.openModal(this.addProfileForm, Category)
    }
    else {
      //console.log("Update")
      this.onSubmit()
    }
  }

  closeModalApp() {
    this.modalService.dismissAll();
    window.location.reload()
  }

  onSubmit() {
    this.modalService.dismissAll();
    this.updateCategory(this.editProfileForm.getRawValue())
    window.location.reload()
   }
}
