// src/app/features/products/pages/product-create/product-create.component.ts

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  Validators,
  ReactiveFormsModule
} from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-create',
  standalone: true,
  imports: [
    CommonModule, 
    ReactiveFormsModule
  ],
  templateUrl: './product-create.component.html'
})
export class ProductCreateComponent {
  form = this.fb.group({
    name: ['', Validators.required],
    price: [0, [Validators.required, Validators.min(0.01)]]
  });

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router
  ) {}

  save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.productService
      .createProduct(this.form.getRawValue() as any)
      .subscribe({
        next: () => {
          this.router.navigate(['/products']);
        }
      });
  }

  cancel(): void {
    this.router.navigate(['/products']);
  }
}