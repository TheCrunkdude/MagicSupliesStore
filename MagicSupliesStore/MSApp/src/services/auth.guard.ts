// auth.guard.ts
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const token = localStorage.getItem('TokenID'); 
    const userPermissions = JSON.parse(sessionStorage.getItem('permissions') || '[]'); 

    if (!token) {
      this.router.navigate(['/login']); 
      return false; 
    }

    const requiredPermissions = route.data['permissions'] as string[]; 

    if (requiredPermissions && !requiredPermissions.some(p => userPermissions.includes(p))) {
      this.router.navigate(['/ErrorPage'], { queryParams: { code: '403', message: 'Access Denied' } });

      return false; 
    }

    return true; 
  }
}
