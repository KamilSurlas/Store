import { Component, OnInit } from '@angular/core';
import { ProductResponseDto } from '../../models/product-response.interface';
import { ProductsService } from '../../services/products.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent implements OnInit{
public product: ProductResponseDto | null = null;
public productId: string | null=null;
constructor(private route: ActivatedRoute,private productsService: ProductsService){};
ngOnInit(): void {
  this.route.params.subscribe(p => {
    this.productId = p['productid'];
  });
  this.productsService.getById(parseInt(this.productId?? "null")).subscribe({
    next: (res) => {
      this.product=res;
    }
  })
}
}


