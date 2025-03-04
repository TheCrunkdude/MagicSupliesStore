import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorCode = error.status || 'Error';
        let errorMessage = '';

        console.log("error",error)
        switch (error.status) {
          case 400: errorMessage = 'Solicitud incorrecta'; break;
          case 401: errorMessage = 'No tienes autorización'; break;
          case 403: errorMessage = 'Acceso prohibido'; break;
          case 404: errorMessage = 'Recurso no encontrado'; break;
          case 500: errorMessage = 'Error interno del servidor'; break;
        }

        // Redirige a la página de error con parámetros
        this.router.navigate(['/ErrorPage'], { queryParams: { code: errorCode, message: errorMessage } });

        return throwError(() => error);
      })
    );
  }
}