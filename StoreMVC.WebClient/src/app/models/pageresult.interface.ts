export interface PageResult<T> {
  items: T[];
  totalPages: number;
  itemFrom: number;
  itemTo: number;
  pageIndex: number;
  totalItemsCount: number;
}
