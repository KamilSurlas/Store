import { SortDirection } from "./sortdirection.interface";

export interface ProductQuery {
  searchPhrase: string | null;
  pageNumber: number;
  pageSize: number;
  sortBy: string | null;
  sortDirection: SortDirection;
}
