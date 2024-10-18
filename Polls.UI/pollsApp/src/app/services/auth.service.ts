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
  ) {}

  login(username: string, password: string): Observable<any> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, { username, password }).pipe(
      tap(response => {
        this.token = response.token;
        this.username = username; // Set the username
        if (isPlatformBrowser(this.platformId)) {
          localStorage.setItem('token', this.token);
        }
        this.router.navigate(['/']);
      })
    );
  }

  register(username: string, password: string, mobilenumber: string, email : string): Observable<any> {
    return this.http.post<{ token: string }>(`${this.apiUrl}/register`, { username, password, email, mobilenumber }).pipe(
      tap(response => {
        this.token = response.token;
        this.username = username; // Set the username
        if (isPlatformBrowser(this.platformId)) {
          localStorage.setItem('token', this.token);
        }
        this.router.navigate(['/login']);
      })
    );
  }

  logout() {
    this.token = null;
    this.username = null;
    if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('token');
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
