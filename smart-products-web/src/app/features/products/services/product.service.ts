import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(
      `${environment.apiUrl}/Products`
    );
  }

  createProduct(data: {
    name: string;
    price: number;
  }): Observable<number> {
    return this.http.post<number>(
      `${environment.apiUrl}/Products`,
      data
    );
  }
}