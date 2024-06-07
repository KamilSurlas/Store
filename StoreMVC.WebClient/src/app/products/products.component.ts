import { Component } from '@angular/core';
import { ProductResponseDto } from '../models/product-response.interface';
import { ProductsService } from '../services/products.service';
import { SortDirection } from '../models/sortdirection.interface';
import { PageResult } from '../models/pageresult.interface';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';
import { importProvidersFrom } from '@angular/core';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css',
})

export class ProductsComponent {
  public pageNumber: number = 1;
  public pageSize: number = 10;
  public searchPhrase: string | null = null;
  public sortBy: string | null = null;
  public sortDirection: SortDirection = SortDirection.ASC;
  public result: PageResult<ProductResponseDto> | null = null;
  public pageSizeOptions: number[] = [5,10,15];
  constructor(private productsService: ProductsService, private router: Router){
    this.loadData();
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
   public onRowChoosed(productId: number):void{
        this.router.navigateByUrl(`/products/${productId}`);
      }
    public handlePageEvent(e: PageEvent) {
        this.result!.totalItemsCount = e.length;
        this.pageSize = e.pageSize;
        this.pageNumber = e.pageIndex + 1;
        this.loadData();
      }
    }

