import { Component, inject, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ComponentsModule } from '../../components/components.module';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { UserTable } from '../interfaces/userTable-interface';
import { AddOrEditUser } from '../models/add-edit-usersmodel';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-users',
  templateUrl: './userspage.component.html',
  styleUrl: './userspage.component.css'
})



export class UsersPageComponent implements OnInit {
  readonly dialog = inject(MatDialog);
  dataSourceUserPage: any;

  constructor (public apiService:ApiService ){

  }

  AddOrEditUser(){
    const dialogRef = this.dialog.open(AddOrEditUser);
    dialogRef.afterClosed().subscribe(
      x => {
      console.log (x)
      })
  }
  CreateUser (){
    
  }

  TestAlert(){
    alertify.success('TU CULO')
  }

  ngOnInit(): void {
    this.LoadUserDataMethod()
    }
    async LoadUserDataMethod() {
      if (this.apiService) {
        this.apiService.getUserTable()
          .subscribe(
            response => {
              // Este dataSource no es el mismo que el de mat table 
              this.dataSourceUserPage = new MatTableDataSource<UserTable>(response);
            })
      }
    
    }
  

}
