import { Component, inject, OnInit, viewChild, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GridComponent } from '../../components/gridcomponent/gridcomponent';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { PermissionsTable } from '../interfaces/permissionsTable-interface';
import { AddOrEditUser } from '../models/add-edit-usersmodel';
import * as alertify from 'alertifyjs';

@Component({
  selector: 'app-permitions',
  templateUrl: './permissions.component.html',
  styleUrl: './permissions.component.css',
})
export class PermissionsPageComponent implements OnInit {

  readonly dialog = inject(MatDialog);
  dataSourcePermissionsPage: any;//cambiar?//
  Permission!: PermissionsTable;
  permissionsColumns: { key: string, header: string }[] = [];
  permissionsHeaders: string[] = [];
  @ViewChild('gridComponent') gridComponent !: GridComponent;

  constructor(public apiService: ApiService) {
  }
  AddOrEditPermission() {
    const modalValues: { modalData: { key: number, columnName: string, value: string, isModal: boolean }[], isEdit: boolean } =
    {
      modalData: [
        { key: 1, columnName: "ID", value: '', isModal: false },
        { key: 2, columnName: "Permission", value: '', isModal: true },
        { key: 3, columnName: "Description", value: '', isModal: true },
      ],
      isEdit: false
    };

    const dialogRef = this.dialog.open(AddOrEditUser, { data: modalValues })
    dialogRef.afterClosed().subscribe(
      x => {

        if (x != null) {
          this.Permission = {
            ID: 0,
            Permission: x[0].valueFromDialog,
            Description: x[1].valueFromDialog,
          };
          console.log(this.Permission)
          this.CreatePermission()
        }
      })

  }
  CreatePermission() {

    this.apiService.getPermissionByName(this.Permission.Permission).subscribe(
      response => {
        if (response != null) {
          alertify.success('El Permiso ya existe')
        }
        else {
          this.apiService.postPermission(this.Permission).subscribe(
            response => {
              alertify.success(response)
              this.LoadpermissionsDataMethod()
            }
          )
        }
      }
    )
  }
  UpdatePermission(event: any): void {
    const modalValues: { modalData: { key: number, columnName: string, value: string, isModal: boolean }[], isEdit: boolean } =
    {
      modalData: [
        { key: 1, columnName: "ID", value: event.id, isModal: false },
        { key: 2, columnName: "Permission", value: event.permission, isModal: true },
        { key: 3, columnName: "Description", value: event.description, isModal: true },
      ],
      isEdit: true
    };
    const dialogRef = this.dialog.open(AddOrEditUser, { data: modalValues })
    dialogRef.afterClosed().subscribe(
      x => {
        if (x != null) {
          this.Permission = {
            ID: event.id,
            Permission: x[0].valueFromDialog,
            Description: x[1].valueFromDialog,
          };
          this.apiService.putPermission(this.Permission).subscribe(
            response => {
              alertify.success(response)
              this.LoadpermissionsDataMethod()
            }
          )
        }
      }
    )
  }

  DeletePermission(event: any): void {
    if (confirm("Are you sure to delete " + event.id)) {
      this.apiService.deletePermission(event.id).subscribe(
        response => {
          alertify.success(response)
          this.LoadpermissionsDataMethod()
        }
      )
    }
  }



  ngOnInit(): void {
    this.LoadGrid()
    this.LoadpermissionsDataMethod()

  }
  async LoadGrid() {

    //Load headers information
    this.permissionsHeaders = ['permission', 'description', 'actions'];

    //Loads columns information
    this.permissionsColumns = [
      { key: 'id', header: 'ID' },
      { key: 'permission', header: 'Permission' },
      { key: 'description', header: 'Description' },
    ];
  }

  async LoadpermissionsDataMethod() {
    if (this.apiService) {
      this.apiService.getPermissions()
        .subscribe(
          response => {
            // Este dataSource no es el mismo que el de mat table 
            this.dataSourcePermissionsPage = new MatTableDataSource<PermissionsTable>(response);
          }
        )
    }
  }
}