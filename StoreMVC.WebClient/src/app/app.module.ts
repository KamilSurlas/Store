import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { AllComponent } from './orders/all/all.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ProductRowComponent } from './product-row/product-row.component';
import { DetailsComponent } from './products/details/details.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent,
    OrdersComponent,
    BasketComponent,
    AllComponent,
    ProductRowComponent,
    DetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
