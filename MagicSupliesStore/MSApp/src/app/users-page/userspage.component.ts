import { Component, inject, OnInit, ViewChild, viewChild } from '@angular/core';
import { MatDialog, MatDialogContainer } from '@angular/material/dialog';
import { ComponentsModule } from '../../components/components.module';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { UserTable } from '../interfaces/userTable-interface';
import { AddOrEditUser } from '../models/add-edit-usersmodel';
import * as alertify from 'alertifyjs';
import { GridComponent } from '../../components/gridcomponent/gridcomponent';
import { DialogService } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-users',
  templateUrl: './userspage.component.html',
  styleUrl: './userspage.component.css'
})



export class UsersPageComponent implements OnInit {
  readonly dialog = inject(MatDialog);
  dataSourceUserPage: any;
  User!: UserTable;

  @ViewChild('gridComponent') gridComponent !: GridComponent;

  constructor(public apiService: ApiService) {

  }

  AddOrEditUser() {
    const dialogRef = this.dialog.open(AddOrEditUser);
    dialogRef.afterClosed().subscribe(
      x => {
        this.User = {
          ID: 0,
          UserName: x.valueFromInput1,
          Password: x.valueFromInput2,
          RoleID: x.valueFromInput3,
          Mail: x.valueFromInput4,
          CreationDate: new Date,
        };
        console.log(this.User)
        this.CreateUser()
      })
  }

  CreateUser() {

    this.apiService.getUserByName(this.User.UserName).subscribe(
      response => {
        if (response != null) {
          alertify.success('El usuario ya existe')
        }
        else {
          this.apiService.postUser(this.User).subscribe(
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

    console.log('Update user method', event)
    const temp = {
      ID: event.id,
      UserName: event.userName,
      Password: event.password,
      RoleID: event.roleID,
      Mail: event.mail,
      CreationDate: new Date(),
      IsEdit: true // Add your new property here
    };

    const dialogRef = this.dialog.open(AddOrEditUser, { data: temp })
    dialogRef.afterClosed().subscribe(
      x => {
        this.User = {
          ID: event.id,
          UserName: x.valueFromInput1,
          Password: x.valueFromInput2,
          RoleID: x.valueFromInput3,
          Mail: x.valueFromInput4,
          CreationDate: new Date,
        };
        console.log(this.User)
        //this update user
        this.apiService.putUser(this.User).subscribe(
          response => {
            alertify.success(response)
            this.LoadUserDataMethod()
          })
      })
  }

  //IMPLEMENT DELETE 
  DeleteUser(event: any): void {

    if (confirm("Are you sure to delete " + event.userName)) {
      this.apiService.deleteUser(event.id).subscribe(
        response => {
          alertify.success(response)
          this.LoadUserDataMethod()
        }
      )
    }
  }
  //!!!!

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
