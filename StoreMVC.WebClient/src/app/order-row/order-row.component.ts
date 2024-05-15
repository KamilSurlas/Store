import { Component, Input } from '@angular/core';
import { OrderResponseDto } from '../models/order-response.interface';

@Component({
  selector: '[app-order-row]',
  templateUrl: './order-row.component.html',
  styleUrl: './order-row.component.css'
})
export class OrderRowComponent {
@Input('app-order-row') order!: OrderResponseDto;
}
