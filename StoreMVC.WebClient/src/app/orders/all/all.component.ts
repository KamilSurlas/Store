import { Component } from '@angular/core';
import { OrderResponseDto } from '../../models/order-response.interface';
import { OrdersService } from '../../services/orders.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
  styleUrl: './all.component.css'
})
export class AllComponent {

  public results : OrderResponseDto[] | null = null;
  constructor(private ordersService: OrdersService, private router: Router){
    this.get();
  }
  public get():void{
    this.ordersService.getAll().subscribe(
      {
      next: (res) => {
        this.results= res
      },
      error: (err) => console.log(err),
      });
  }
  public onOrderChoosed(orderId: number) {
    this.router.navigateByUrl(`orders/all/${orderId}`);
    }
}

