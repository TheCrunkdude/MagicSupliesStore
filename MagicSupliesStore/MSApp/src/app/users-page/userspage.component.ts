import { Component, inject, OnInit, ViewChild, viewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ComponentsModule } from '../../components/components.module';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { UserTable } from '../interfaces/userTable-interface';
import { AddOrEditUser } from '../models/add-edit-usersmodel';
import * as alertify from 'alertifyjs';
import { response } from 'express';
import { GridComponent } from '../../components/gridcomponent/gridcomponent';

@Component({
  selector: 'app-users',
  templateUrl: './userspage.component.html',
  styleUrl: './userspage.component.css'
})



export class UsersPageComponent implements OnInit {
  readonly dialog = inject(MatDialog);
  dataSourceUserPage: any;
  newUser!: UserTable;

  @ViewChild('gridComponent') gridComponent !: GridComponent;

  constructor(public apiService: ApiService) {

  }

  AddOrEditUser() {
    const dialogRef = this.dialog.open(AddOrEditUser);
    dialogRef.afterClosed().subscribe(
      x => {
        this.newUser = {
          ID: 0,
          UserName: x.valueFromInput1,
          Password: x.valueFromInput2,
          RoleID: x.valueFromInput3,
          Mail: x.valueFromInput4,
          CreationDate: new Date,
        };
        console.log(this.newUser)
        this.CreateUser()
      })
  }

  CreateUser() {

    this.apiService.getUserByName(this.newUser.UserName).subscribe(
      response => {
        if (response != null) {
          alertify.success('El usuario ya existe')
        }
        else {
          this.apiService.postUser(this.newUser).subscribe(
            response => {
              alertify.success(response)
              this.LoadUserDataMethod()
            }
          )
        }
      }
    )
  }

  UpdateUser(event: any): void {
    console.log(event)
    alertify.success(event.toString())
  }

  TestAlert() {
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
