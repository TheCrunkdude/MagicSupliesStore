import { Component, inject, model, OnInit, signal, ViewChild } from '@angular/core';
import { DialogData, LoginInputComponent } from '../components/component-login/componentlogin';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { ApiService, loginModel } from '../services/api.service';

  @Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit
  {
    @ViewChild('loginComponent') loginComponent!: LoginInputComponent;

    readonly field1 = signal('');
    readonly valuefromInput2 = model('');
    readonly dialog = inject(MatDialog);

    constructor(private router: Router, private ApiService: ApiService){//Aqui construimos nuestro objeto " ApiService" y //
      
    }

    openSignUpDialog(): void {
      const dialogRef = this.dialog.open(LoginInputComponent);
  
      dialogRef.afterClosed().subscribe(
        (result: any) => {
        console.log('The dialog was closed');
        if (result !== undefined) {

          let request: loginModel = {
            User : result.valueFromInput1 ,
            Password : result.valueFromInput2
          }

          let result2 = ''
      this.ApiService.postData(request).subscribe(
        response => {
          result2 = response;
          console.log(result2)
          localStorage.setItem( 'TokenID', result2)
        })  
        }
      });
    }
    ngOnInit ():void{
    }
  title = 'MSApp';
}
