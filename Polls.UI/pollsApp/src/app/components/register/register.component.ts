import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  username: string = '';
  mobilenumber: string = '';
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService) {}

  onSubmit() {
    this.authService.register(this.username, this.password, this.email, this.mobilenumber).subscribe({
      next: (response : string) => {
        console.log('Registration successful', response);
      },
      error: (error : string) => {
        console.error('Login failed', error);
      },
    });
  }
}