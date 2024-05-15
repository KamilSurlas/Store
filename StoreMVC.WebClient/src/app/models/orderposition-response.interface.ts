import { ProductResponseDto } from "./product-response.interface";

export interface OrderPositionResponseDto {
  price: number;
  amount: number;
  product: ProductResponseDto;
}
