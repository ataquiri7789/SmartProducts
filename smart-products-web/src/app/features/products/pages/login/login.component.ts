
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  loading = false;

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  login(): void {
    this.loading = true;

    this.authService.login().subscribe({
      next: () => {
        this.router.navigate(['/products']);
      },
      error: () => {
        this.loading = false;
        alert('Error al iniciar sesión');
      }
    });
  }
}