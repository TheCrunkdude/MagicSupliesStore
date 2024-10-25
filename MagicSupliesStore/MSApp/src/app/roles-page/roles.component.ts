import { Component, inject, OnInit, viewChild, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GridComponent } from '../../components/gridcomponent/gridcomponent';
import { RolesTable } from '../interfaces/rolesTable-interface';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { AddEditRolesModel } from '../models/add-edit-rolemodel';
import * as alertify from 'alertifyjs';

@Component({
    selector: 'app-roles',
    templateUrl: './roles.component.html',
    styleUrl: './roles.component.css'
})
export class RolesPageComponent implements OnInit {

    readonly dialog = inject(MatDialog);
    dataSourceRolesPage: any;//cambiar?//
    Role!: RolesTable;
    roleColumns: {key:string, header:string}[] = [];
    roleHeaders: string[] = [];
    @ViewChild('gridComponent') gridComponent !: GridComponent

    constructor(public apiService: ApiService) {
}
    ngOnInit(): void {
        this.LoadGrid()
        this.LoadRolesDataMethod()
    }
    AddOrEditRole() {
      const dialogRef = this.dialog.open(AddEditRolesModel);
      dialogRef.afterClosed().subscribe(
        x => {
          this.Role = {
            ID: 0,
            permissionsID: x.valueFromInput1,
            role: x.valueFromInput2
          };
          console.log(this.Role)
          this.CreateRole()
        })
    }

    CreateRole() {

      this.apiService.getCheckRole(this.Role.role).subscribe(
        response => {
          if (response != null) {
            alertify.success('El rol ya existe')
          }
          else {
            this.apiService.postRole(this.Role).subscribe(
              response => {
                alertify.success(response)
                this.LoadRolesDataMethod()
              }
            )
          }
        }
      )
    }

  UpdateRole(event: any): void {

    console.log('Update Role method', event)
    const temp = {
      ID: event.id,
      PermissioID: event.permissionsID,
      Role: event.role,
      IsEdit: true // Add your new property here
    };

    const dialogRef = this.dialog.open(AddEditRolesModel, { data: temp })
    dialogRef.afterClosed().subscribe(
      x => {
        this.Role = {
          ID: event.id,
          permissionsID: x.valueFromInput1,
          role: x.valueFromInput2,
        };
        console.log(this.Role)
        //this update user
        this.apiService.putRole(this.Role).subscribe(
          response => {
            alertify.success(response)
            this.LoadRolesDataMethod()
          })
      })
  }

  //IMPLEMENT DELETE 
  DeleteRole(event: any): void {

    if (confirm("Are you sure to delete " + event.role)) {
      this.apiService.deleteRole(event.id).subscribe(
        response => {
          alertify.success(response)
          this.LoadRolesDataMethod()
        }
      )
    }
  }
  //!!!!
  
    async LoadGrid() {

        //Load headers information
        this.roleHeaders = ['id', 'permissionsID', 'role', 'actions'];

        //Loads columns information
        this.roleColumns = [
            { key: 'id', header: 'ID' },
            { key: 'permissionsID', header: 'Permissions ID' },
            { key: 'role', header: 'Role' },
        ];
    }

  async LoadRolesDataMethod() {
    if (this.apiService) {
      this.apiService.getRolesTable()
        .subscribe(
          response => {
            // Este dataSource no es el mismo que el de mat table 
            this.dataSourceRolesPage = new MatTableDataSource<RolesTable>(response);
          })
    }

  }

}