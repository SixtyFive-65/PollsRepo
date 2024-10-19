import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  loginError: boolean = false;

  constructor(private authService: AuthService) {}

  onSubmit(form: NgForm) {
    if (form.valid) {
    this.authService.login(this.username, this.password).subscribe({
      next: (response : string) => {
        console.log('Login successful', response);
        // Store JWT token or user data as needed
        localStorage.setItem('token', response); // Adjust based on your API response
        this.loginError = false; // Set error state
      },
      error: (error) => {
        if (error.status === 401) {
          this.loginError = true; // Set error state
        }
        console.error('Login failed', error);
      },
    });
  }else{
    console.error('Form is invalid');
  }
  }
}