import { Component, OnInit, importProvidersFrom } from '@angular/core';
import { ProductResponseDto } from '../../models/product-response.interface';
import { ProductsService } from '../../services/products.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent{
public deleteError: string | null=null;
public product: ProductResponseDto | null = null;
public productId: number;
constructor(private route: ActivatedRoute,private productsService: ProductsService,private router: Router){
    this.productId=Number(this.route.snapshot.params['productid'])
    this.productsService.getById(this.productId).subscribe({
      next: (res) => {
        this.product=res;
      },
      error: (err) => {
        console.log(err);
      }, 
    })
  };
  public changeProductAvailability():void{
    this.productsService.changeAvailability(this.productId).subscribe({
      next: () => {
        window.location.reload();
        console.log('Product activated successfully')
      },
      error: (err) => {
        console.log(err);
      },
    })
  }
  public deleteProduct():void{
    this.productsService.delete(this.productId).subscribe({
      next: () => {
        this.router.navigateByUrl('/products');
      },
      error: (err) => {
        this.deleteError = err.error;
      }
    })
  }
};



