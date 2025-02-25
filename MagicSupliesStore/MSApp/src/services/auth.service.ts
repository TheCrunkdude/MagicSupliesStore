import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() {}

  // Check if a token exists
  isLoggedIn(): boolean {
    const token = localStorage.getItem('TokenID');
    return !!token && !this.isTokenExpired(token);
  }

  // Decode the token and check if it's expired
  isTokenExpired(token: string): boolean {
    const payload = JSON.parse(atob(token.split('.')[1])); // Decode payload
    const expiry = payload.exp;
    return (Math.floor(new Date().getTime() / 1000)) >= expiry; // Compare expiry time
  }

  // Get token from localStorage
  getToken(): string | null {
    return localStorage.getItem('token');
  }
}