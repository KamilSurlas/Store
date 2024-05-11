import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { AllComponent } from './orders/all/all.component';
import { DetailsComponent } from './products/details/details.component';
const routes: Routes = [
  {path:'products', component: ProductsComponent},
  {path:'orders',component: OrdersComponent},
  {path:'orders/all',component: AllComponent},
  {path: 'basket', component: BasketComponent},
  {path: 'products/:productid', component: DetailsComponent},
  {path: '', redirectTo: 'products', pathMatch: 'full'}
  ];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
