import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    selector: 'error-page',
    templateUrl: './error-page.html',
    styleUrls: ['./error-page.css']
  })
  export class ErrorComponent {
    errorCode: string = 'Error';
    errorMessage: string = 'Ha ocurrido un error inesperado';
  
    constructor(private route: ActivatedRoute, private router: Router) {
      this.route.queryParams.subscribe(params => {
        this.errorCode = params['code'] || 'Error';
        this.errorMessage = params['message'] || 'Ha ocurrido un error inesperado';
      });
    }
  
    navigateTo(path: string) {
      this.router.navigate([path]);
    }
  }