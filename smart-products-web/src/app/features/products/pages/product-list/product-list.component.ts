import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  filteredProducts: Product[] = [];

  searchCode = '';
  searchName = '';

  constructor(
    private productService: ProductService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe({
      next: (response) => {
        this.products = response;
        this.filteredProducts = [...response];
      },
      error: (error) => {
        console.error('Error al obtener productos', error);
      }
    });
  }

  filterProducts(): void {
    const code = this.searchCode.trim();
    const name = this.searchName.toLowerCase().trim();

    this.filteredProducts = this.products.filter(product => {
      const matchCode =
        !code || product.id.toString().includes(code);

      const matchName =
        !name || product.name.toLowerCase().includes(name);

      return matchCode && matchName;
    });
  }

  clearFilters(): void {
    this.searchCode = '';
    this.searchName = '';
    this.filteredProducts = [...this.products];
  }

  goToCreate(): void {
    this.router.navigate(['/create-product']);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}