import { Component } from '@angular/core';
import { OrderPositionResponseDto } from '../../../models/orderposition-response.interface';
import { OrdersService } from '../../../services/orders.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './orderdetails.component.html',
  styleUrl: './orderdetails.component.css'
})
export class OrderdetailsComponent {
  public orderId!:number;
  public results!: OrderPositionResponseDto[];
  constructor(private ordersService: OrdersService, private router: Router,private route: ActivatedRoute){
    this.orderId=Number(this.route.snapshot.params['orderid']);
    this.ordersService.getOrderById(this.orderId).subscribe({
      next: (res) => {
        this.results=res.orderPositions;
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    })
  };
}
