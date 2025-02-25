// auth.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    if (this.authService.isLoggedIn()) {
        console.log('is logged in retorno true')

      return true; // Allow access
    } 
    else {
      this.router.navigate(['']); // Redirect to login if not authorized
      console.log('is logged in retorno false')
      
      return false;
    }
  }
}