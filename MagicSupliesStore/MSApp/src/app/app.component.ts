import { Component, inject, model, signal, ViewChild } from '@angular/core';
import { LoginInputComponent } from '../components/component-login/componentlogin';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';


  @Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent 
  {
    @ViewChild('loginComponent') loginComponent!: LoginInputComponent;

    readonly animal = signal('');
    readonly name = model('');
    readonly dialog = inject(MatDialog);
  

    constructor(private router: Router){}

    openSignUpDialog(): void {
      const dialogRef = this.dialog.open(LoginInputComponent, {
        data: {name: this.name(), animal: this.animal()},
      });
  
      dialogRef.afterClosed().subscribe(result => {
        console.log('The dialog was closed');
        if (result !== undefined) {
          this.animal.set(result);
          alert (this.loginComponent.inputComponent1.value)
        }
      });
    }
  title = 'MSApp';
}
