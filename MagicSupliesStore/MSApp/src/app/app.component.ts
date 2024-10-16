import { AfterViewInit, Component, inject, model, OnInit, signal, ViewChild } from '@angular/core';
import { DialogData, LoginInputComponent } from '../components/component-login/componentlogin';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { ApiService, loginModel } from '../services/api.service';
import { Route } from '@angular/router';
  @Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent implements OnInit
  {
    ngOnInit ():void{
    }

  title = 'MSApp';
}
