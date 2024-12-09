import { AfterViewInit, Component, inject, model, OnInit, signal, ViewChild } from '@angular/core';
import { DialogData, LoginInputComponent } from '../../components/component-login/componentlogin';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { ApiService, LoginModel } from '../../services/api.service';

@Component({
  selector: 'app-loginpage',
  templateUrl: './loginpage.html',
  styleUrl: './loginpage.css'
})

export class LoginpageComponent implements OnInit {
  @ViewChild('loginComponent') loginComponent!: LoginInputComponent;

  readonly field1 = signal('');
  readonly valuefromInput2 = model('');
  readonly dialog = inject(MatDialog);


  constructor(private router: Router, private ApiService: ApiService) {//Aqui construimos nuestro objeto " ApiService" y //

  }
  // ngAfterViewInit(): void {
  //   document.getElementById('ClassMain')?.remove
  // }

  openSignUpDialog(): void {
    const dialogRef = this.dialog.open(LoginInputComponent);

    dialogRef.afterClosed().subscribe(
      (result: any) => {
        console.log('The dialog was closed');
        if (result !== undefined) {

          let request: LoginModel = {
            User: result.valueFromInput1,
            Password: result.valueFromInput2
          }

          this.ApiService.postData(request).subscribe(
            response => {
              localStorage.setItem('TokenID', response)
              this.navigate()
            })

        }
      });



  }
  navigate(): void {


    if (localStorage.getItem('TokenID') != ' ') {
      this.router.navigate(['MainPage'])
    }

  }


  ngOnInit(): any {

    const menuDiv = document.getElementById("MENUDIVID");
    if (menuDiv) 
      menuDiv.style.display = "none";
    
    const backDiv = document.getElementById("back");
    if (backDiv) 
      backDiv.style.background = "none";

    console.log('Mainpage funcionando')


  }

}