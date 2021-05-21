import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ConfigGeneralComponent } from './components/config-general/config-general.component';
import { CrudProductComponent } from './components/crud-product/crud-product.component';
import { ViewUsersComponent } from './components/view-users/view-users.component';
import { CrudCategoryComponent } from './components/crud-category/crud-category.component';
import { ViewOrdersComponent } from './components/view-orders/view-orders.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: 'home',
    component: HomeComponent,
    data: { title: 'Home' }
  },
  {
    path: 'parametros/generales',
    component: ConfigGeneralComponent,
    data: { title: 'Parametros Generales' }
  },
  {
    path: 'mantenimientos/productos',
    component: CrudProductComponent,
    data: { title: 'Productos' }
  },
  {
    path: 'mantenimientos/prod-categorias',
    component: CrudCategoryComponent,
    data: { title: 'Productos' }
  },  
  {
    path: 'consultas/usuarios',
    component: ViewUsersComponent,
    data: { title: 'Usuarios' }
  },
  {
    path: 'consultas/ordenes',
    component: ViewOrdersComponent,
    data: { title: 'Ordenes' }
  }
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
