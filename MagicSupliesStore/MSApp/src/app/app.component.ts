import { Component, inject, model, signal, ViewChild } from '@angular/core';
import { LoginInputComponent } from '../components/component-login/componentlogin';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { map } from 'rxjs';


  @Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent 
  {
    @ViewChild('loginComponent') loginComponent!: LoginInputComponent;

    readonly field1 = signal('');
    readonly valuefromInput2 = model('');
    readonly dialog = inject(MatDialog);
  

    constructor(private router: Router){}

    openSignUpDialog(): void {
      const dialogRef = this.dialog.open(LoginInputComponent);
  
      dialogRef.afterClosed().pipe(map(
        //use the pipe and map methods to update or change the result before hitting the subscribe block
        result => result = JSON.stringify(result)
      )).subscribe(result => {
        console.log('The dialog was closed');
        if (result !== undefined) {
          console.log('App LEVEL ===> result')
          console.log(result)
          alert (result)
        }
      });
    }
  title = 'MSApp';
}
