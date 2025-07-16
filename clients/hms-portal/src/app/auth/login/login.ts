import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Auth } from '../auth';
import { Router } from '@angular/router'; // Import Router

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.scss'
})
export class Login{
  loginData = { email: '', password: '' };

  constructor(private authService: Auth, private router: Router) {}

  onSubmit() {
    console.log('Attempting to log in with:', this.loginData);

    this.authService.login(this.loginData.email, this.loginData.password)
      .subscribe({
        next: (response) => {
          console.log('Login successful! Token response:', response);
          this.router.navigate(['/guests']); // Navigate on success
        },
        error: (err) => {
          console.error('Login failed:', err);
        }
      });
  }
}
