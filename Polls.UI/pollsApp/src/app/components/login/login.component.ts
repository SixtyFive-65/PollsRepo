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

  constructor(private authService: AuthService) {}

  onSubmit(form: NgForm) {
    if (form.valid) {
    this.authService.login(this.username, this.password).subscribe({
      next: (response : string) => {
        console.log('Login successful', response);
        // Store JWT token or user data as needed
        localStorage.setItem('token', response); // Adjust based on your API response
      },
      error: (error : string) => {
        console.error('Login failed', error);
      },
    });
  }else{
    console.error('Form is invalid');
  }
  }
}