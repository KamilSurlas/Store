import { Component } from '@angular/core';
import { ProductResponseDto } from '../models/product-response.interface';
import { ProductsService } from '../services/products.service';
import { SortDirection } from '../models/sortdirection.interface';
import { PageResult } from '../models/pageresult.interface';
import { Router } from '@angular/router';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public pageNumber: number = 1;
  public pageSize: number = 10;
  public searchPhrase: string | null = null;
  public sortBy: string | null = null;
  public sortDirection: SortDirection = SortDirection.ASC;
  public result: PageResult<ProductResponseDto> | null = null;
  public choosenProduct: ProductResponseDto | null = null;
  constructor(private productsService: ProductsService, private router: Router){
    this.productsService.get({pageSize: this.pageSize, pageNumber:this.pageNumber, searchPhrase: this.searchPhrase, sortBy: this.sortBy, sortDirection: this.sortDirection}).subscribe(
      {
      next: (res) => {
        console.log(res),
        this.result= res;

      },
      error: (err) => console.log(err),
      complete: ()=>console.log('complete')
      });
  }
  private loadData():void{
    this.productsService.get({pageSize: this.pageSize, pageNumber:this.pageNumber, searchPhrase: this.searchPhrase, sortBy: this.sortBy, sortDirection: this.sortDirection}).subscribe(
      {
      next: (res) => {
        console.log(res),
        this.result= res

      },
      error: (err) => console.log(err),
      complete: ()=>console.log('complete')
      });
  }
  public onPaginationSubmit(): void{
    this.loadData();
   }
   public onRowChoosed(event: ProductResponseDto):void{
        this.router.navigateByUrl(`/products/details/${event.productId}`); 
      }
    }
   
