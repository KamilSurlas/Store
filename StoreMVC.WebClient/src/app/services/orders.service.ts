import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderResponseDto } from '../models/order-response.interface';
import { Observable } from 'rxjs';
import { OrderPositionResponseDto } from '../models/orderposition-response.interface';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private apiUrl : string = `https://localhost:7208/api/orders/`;
  constructor(private httpClient: HttpClient) { }
public getAll(): Observable<OrderResponseDto[]>
{
return this.httpClient.get<OrderResponseDto[]>(this.apiUrl + 'all');
}
public getOrderById(orderId:number):  Observable<OrderResponseDto>
{
  return this.httpClient.get<OrderResponseDto>(this.apiUrl+orderId);
}
}
