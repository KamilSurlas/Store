import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductResponseDto } from '../models/product-response.interface';

@Component({
  selector: '[app-product-row]',
  templateUrl: './product-row.component.html',
  styleUrl: './product-row.component.css'
})
export class ProductRowComponent {
@Input('app-product-row') product!: ProductResponseDto;
@Output() choosed = new EventEmitter<ProductResponseDto>();
public onChooseClick():void{
  this.choosed.emit(this.product);
}
}
