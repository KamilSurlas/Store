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
  private apiUrl : string = `https://localhost:7208/api/products/`;
  constructor(private httpClient: HttpClient) { }


public get(pagination: ProductQuery): Observable<PageResult<ProductResponseDto>>
{
  const httpParams=new HttpParams().append("pageNumber",pagination.pageNumber).append("pageSize", pagination.pageSize).append("searchPhrase",pagination.searchPhrase ?? "").append("sortBy",pagination.sortBy ?? "").append("sortDirection",pagination.sortDirection);
const params = httpParams;
return this.httpClient.get<PageResult<ProductResponseDto>>(this.apiUrl, {params: params});

}
public getById(productId: number):Observable<ProductResponseDto>{
  return this.httpClient.get<ProductResponseDto>(this.apiUrl + productId);
}
public changeAvailability(productId:number):Observable<void>{
  return this.httpClient.patch<void>(this.apiUrl + productId, null);
}
public delete(productId:number):Observable<void>{
  return this.httpClient.delete<void>(this.apiUrl + productId);
}
}
  