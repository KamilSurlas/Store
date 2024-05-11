import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductQuery } from '../models/pagination.interface';
import { Observable } from 'rxjs';
import { ProductResponseDto } from '../models/product-response.interface';
import { PageResult } from '../models/pageresult.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient: HttpClient) { }


public get(pagination: ProductQuery): Observable<PageResult<ProductResponseDto>>
{
  const httpParams=new HttpParams().append("pageNumber",pagination.pageNumber).append("pageSize", pagination.pageSize).append("searchPhrase",pagination.searchPhrase ?? "").append("sortBy",pagination.sortBy ?? "").append("sortDirection",pagination.sortDirection);
const params = httpParams;
return this.httpClient.get<PageResult<ProductResponseDto>>('https://localhost:7208/api/products', {params: params});

}
public getById(productId: number):Observable<ProductResponseDto>{
  return this.httpClient.get<ProductResponseDto>(`https://localhost:7208/api/products/${productId}`);
}

}
  