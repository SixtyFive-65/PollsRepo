import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5242'; // Replace with your API URL
  private token: string | null = null;
  public username: string | null = null;

  constructor(
    private http: HttpClient,
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {
    // Restore the token and username from localStorage on initialization
    if (isPlatformBrowser(this.platformId)) {
      this.token = localStorage.getItem('token');
      this.username = localStorage.getItem('username'); // Restore username
    }
  }

  login(username: string, password: string): Observable<any> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, { username, password }).pipe(
      tap(response => {
        this.token = response.token;
        this.username = username; // Set the username
        if (isPlatformBrowser(this.platformId)) {
          localStorage.setItem('token', this.token);
          localStorage.setItem('username', this.username); // Store the username
        }
        this.router.navigate(['/']);
      })
    );
  }

  register(username: string, email: string, mobilenumber: string, password: string,  ): Observable<any> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/register`, { username: username, email: email,  mobilenumber: mobilenumber, password: password }).pipe(
      tap(response => {
        this.token = response.token;
        this.username = username; // Set the username
        if (isPlatformBrowser(this.platformId)) {
          localStorage.setItem('token', this.token);
          localStorage.setItem('username', this.username); // Store the username
        }
        this.router.navigate(['/']);
      })
    );
  }

  logout() {
    this.token = null;
    this.username = null;
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('token');
      localStorage.removeItem('username'); // Remove the username
    }
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      return this.token !== null || localStorage.getItem('token') !== null;
    }
    return false; // Not logged in if not in the browser
  }
}
