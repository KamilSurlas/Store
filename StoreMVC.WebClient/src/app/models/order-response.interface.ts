import { OrderPositionResponseDto } from "./orderposition-response.interface";

export interface OrderResponseDto {
  orderId: number;
  date: string;
  orderPositions: OrderPositionResponseDto[];
}
