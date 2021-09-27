import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatSidenavModule} from '@angular/material/sidenav';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { HomeComponent } from './components/home/home.component';

import {FormsModule} from '@angular/forms'
import {MaterialModule} from './modules/material/material.module';
import { StoreModule } from '@ngrx/store'

import {CommonModule} from '@angular/common'

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { ConfigGeneralComponent } from './components/config-general/config-general.component';
import { CrudProductComponent } from './components/crud-product/crud-product.component';

import { HttpClientModule } from '@angular/common/http';
import { ViewUsersComponent } from './components/view-users/view-users.component';
import { TopBarComponent } from './components/top-bar/top-bar.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CrudCategoryComponent } from './components/crud-category/crud-category.component';
import { ViewOrdersComponent } from './components/view-orders/view-orders.component';
import { ReactiveFormsModule } from '@angular/forms';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};


@NgModule({
  declarations: [
    AppComponent,
    SideNavComponent,
    HomeComponent,
    ConfigGeneralComponent,
    CrudProductComponent,
    ViewUsersComponent,
    TopBarComponent,
    CrudCategoryComponent,
    ViewOrdersComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    HttpClientModule,
    FormsModule, 
    MaterialModule, StoreModule.forRoot({}, {}),
    PerfectScrollbarModule,
    NgbModule,
    ReactiveFormsModule,
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
