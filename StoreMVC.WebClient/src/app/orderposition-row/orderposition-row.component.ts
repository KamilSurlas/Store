import { Component, Input } from '@angular/core';
import { OrderPositionResponseDto } from '../models/orderposition-response.interface';

@Component({
  selector: '[app-orderposition-row]',
  templateUrl: './orderposition-row.component.html',
  styleUrl: './orderposition-row.component.css'
})
export class OrderpositionRowComponent {
@Input('app-orderposition-row') orderposition!: OrderPositionResponseDto;
}
