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
  saveProfileForm: FormGroup;
  message: string;
  closeResult: string;
  SelectedCategory: Category;
  constructor(
    private fb: FormBuilder,
    public categoryService: CategoryService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.getCategories();

    this.saveProfileForm = this.fb.group({
      id: [''],
      identificator: [''],
      description: ['']
    });

    this.SelectedCategory = null;
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

  createCategory(category){
    this.categoryService.create(category).subscribe(
      response =>{
        console.log(response);
        this.message = response.message ? response.message : 'This category was updated successfully!';
      },
      error =>{
        console.log(error);
      }
    );
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
    
    if (category === "") 
    {
      this.saveProfileForm.patchValue({
        id: "",
        identificator: "",
        description: ""
      });
      this.SelectedCategory = null;
    }
    else 
    {
      this.saveProfileForm.patchValue({
        id: category.id,
        identificator: category.identificator,
        description: category.description
      });
      this.SelectedCategory = category;
    }
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

  closeModalApp() {
    this.modalService.dismissAll();
    window.location.reload()
  }

  onSubmit() {
    this.modalService.dismissAll();
    
    if (this.SelectedCategory === null) 
    {
      let newCategory = new Category();
      newCategory.Id = 0;
      newCategory.CreatedBy = 'Hiciano';
      newCategory.CreationDate = new Date();
      newCategory.ModificatedBy = 'Hiciano';
      newCategory.ModificationDate = new Date();
      newCategory.IsDeleted = false;
      newCategory.Identificator = this.saveProfileForm.value.identificator; 
      newCategory.Description = this.saveProfileForm.value.description;
      newCategory.OnTopInMainPage = false;
      this.createCategory(JSON.stringify(newCategory))
    }
    else
    {
      this.updateCategory(this.saveProfileForm.getRawValue())
    }

    window.location.reload()
   }

   
}
