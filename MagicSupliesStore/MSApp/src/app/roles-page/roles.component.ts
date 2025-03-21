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
    roles!: RolesTable;
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
      
      const temp = {
        ID: 0,
        Role: '',
        IsEdit: false // Add your new property here
      };
      const dialogRef = this.dialog.open(AddEditRolesModel, { data: temp });
      dialogRef.afterClosed().subscribe(
        x => {
          this.roles = {
            id: 0,
            role: x.valueFromInput1
          };
          console.log(this.roles)
          this.CreateRole()
        })
    }

    CreateRole() {

      this.apiService.getCheckRole(this.roles.role).subscribe(
        response => {
          if (response != null) {
            alertify.success('El rol ya existe')
          }
          else {
            this.apiService.postRole(this.roles).subscribe(
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
      role: event.role,
      IsEdit: true // Add your new property here
    };

    const dialogRef = this.dialog.open(AddEditRolesModel, { data: temp })
    dialogRef.afterClosed().subscribe(
      x => {

        this.roles = {
          id: event.id,
          role: x.valueFromInput1,
        };
        console.log('Role',this.roles, 'x', x)
        //this update user
        this.apiService.putRole(this.roles).subscribe(
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
        this.roleHeaders = ['id', 'role', 'actions'];

        //Loads columns information
        this.roleColumns = [
            { key: 'id', header: 'ID' },
            // { key: 'permissionsID', header: 'Permissions ID' },
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