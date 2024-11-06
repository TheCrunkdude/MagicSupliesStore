import { Component, inject, OnInit, ViewChild } from '@angular/core';
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
  userColumns: { key: string, header: string }[] = [];
  userHeaders: string[] = [];

  @ViewChild('gridComponent') gridComponent !: GridComponent;

  constructor(public apiService: ApiService) {

  }

  AddOrEditUser() {

    const modalValues: {modalData: {key: number, columnName:string, value: string, isModal:boolean}[], isEdit: boolean } = 
    {modalData: [
      {key: 1, columnName: "ID", value: '',isModal:false},
      {key: 2, columnName: "UserName", value: '', isModal:true},
      {key: 3, columnName: "Password", value: '', isModal:true},
      {key: 4, columnName: "RoleID", value: '', isModal:true},
      {key: 5, columnName: "Mail", value: '', isModal:true},
      {key: 6, columnName: "CreationDate", value: new Date().toString(), isModal:false},
    ], 
    isEdit: false};

    const dialogRef = this.dialog.open(AddOrEditUser, { data: modalValues })
    dialogRef.afterClosed().subscribe(
      x => {

        if (x != null)
          {
        this.User = {
          ID: 0,
          UserName: x[0].valueFromDialog,
          Password: x[1].valueFromDialog,
          RoleID: x[2].valueFromDialog,
          Mail: x[3].valueFromDialog,
          CreationDate: new Date,
        };
        console.log(this.User)
        this.CreateUser()
          }
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

    const modalValues: {modalData: {key: number, columnName:string, value: string, isModal:boolean}[], isEdit: boolean } = 
    {modalData: [
      {key: 1, columnName: "ID", value: event.id,isModal:false},
      {key: 2, columnName: "UserName", value: event.userName, isModal:true},
      {key: 3, columnName: "Password", value: event.password, isModal:true},
      {key: 4, columnName: "RoleID", value: event.roleID, isModal:true},
      {key: 5, columnName: "Mail", value: event.mail, isModal:true},
      {key: 6, columnName: "CreationDate", value: new Date().toString(), isModal:false},
    ], 
    isEdit: true};
    const dialogRef = this.dialog.open(AddOrEditUser, { data: modalValues })


    dialogRef.afterClosed().subscribe(
      x => {
        if (x != null)
        {
          this.User = {
            ID: event.id,
            UserName: x[0]?.valueFromDialog,
            Password: x[1]?.valueFromDialog,
            RoleID: x[2]?.valueFromDialog,
            Mail: x[3]?.valueFromDialog,
            CreationDate: new Date
          };
          //this update user
          this.apiService.putUser(this.User).subscribe(
            response => {
              alertify.success(response)
              this.LoadUserDataMethod()
            })
        }
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
    this.LoadGrid()
    this.LoadUserDataMethod()
  }

  async LoadGrid() {

    //Load headers information
    this.userHeaders = ['id', 'userName', 'password',
      'roleID', 'mail', 'creationDate', 'actions'];

    //Loads columns information
    this.userColumns = [
      { key: 'id', header: 'ID' },
      { key: 'userName', header: 'UserName' },
      { key: 'password', header: 'Password' },
      { key: 'roleID', header: 'Role ID' },
      { key: 'mail', header: 'Mail' },
      { key: 'creationDate', header: 'Creation Date' },
    ];

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
