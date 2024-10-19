import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  username: string = '';
  email: string = '';
  mobilenumber: string = '';
  password: string = '';
  registerError: boolean = false;

  constructor(private authService: AuthService) {}

  onSubmit(form: NgForm) {
    if(form.valid){

    this.authService.register(this.username, this.email, this.mobilenumber, this.password).subscribe({
      next: (response : string) => {
        console.log('Registration successful', response);
      },
      error: (error) => {
        if (error.status === 400) {
          this.registerError = true; // Set error state
        }
        console.error('Registration failed', error);
      },
    });
  }else{
    console.error('Form is invalid')
  }
  }

  onMobileNumberInput(event: any): void {
    const input = event.target as HTMLInputElement;
    input.value = input.value.replace(/\D/g, '');  // Replace non-numeric characters
  }
}