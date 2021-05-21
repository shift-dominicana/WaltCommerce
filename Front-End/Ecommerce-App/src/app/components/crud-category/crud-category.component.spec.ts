import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudCategoryComponent } from './crud-category.component';

describe('CrudCategoryComponent', () => {
  let component: CrudCategoryComponent;
  let fixture: ComponentFixture<CrudCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrudCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrudCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
