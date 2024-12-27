import { Component, inject, OnInit, ViewChild } from "@angular/core";
import { rolePermissionsTable } from "../interfaces/rolesPermissionsTable-interface";
import { GridComponent } from "../../components/gridcomponent/gridcomponent";
import { ApiService } from "../../services/api.service";
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from "@angular/material/dialog";
import { TableComponent } from "../../components/tableComponent/tableComponent";
import { Checkbox } from "primeng/checkbox";
import { PermissionsTable } from "../interfaces/permissionsTable-interface";
import { state } from "@angular/animations";
import { RolesPageComponent } from "../roles-page/roles.component";
import { Console } from "console";


@Component({
  selector: 'app-rolePermissions',
  templateUrl: './rolePermissions.component.html',
  styleUrl: './rolePermissions.component.css',
})
export class RolePermissionsPageComponent implements OnInit {

  readonly dialog = inject(MatDialog);
  dataSourceRolePermissionsPage: any;//cambiar?//
  RolePermission: rolePermissionsTable[] = [];
  rolePermissionsColumns: { key: string, header: string }[] = [];
  rolePermissionsHeaders: string[] = [];
  rows = ['Permission 1', 'Permission 2', 'Permission 3', 'Permission 4', 'Permission 5', 'Permission 6',];
  columns = ['Role 1', 'Role 2', 'Role 3', 'Role 4', 'Role 5','Role 6'];
  grid: boolean[][] = Array.from({ length: 6 }, () => Array(6).fill(false));
  permissionRequest:rolePermissionsTable[] = [];


  @ViewChild('gridComponent') gridComponent !: GridComponent;
  
  async toggleChanges(event:any): Promise<void> {
    let result: any; // Declarar la variable fuera del 'if'
    
    result = {id: 0, role: event.colIndex + 1, permission: event.rowIndex + 1, active: event.active}        
    

    if (result){
      this.permissionRequest = this.permissionRequest.filter(
        (entry: any) =>
          entry.role !== result.role || entry.permission !== result.permission
      );
      this.permissionRequest.push(result)
    }
    else 
    {
      console.log('algo fallo!')
    }
    console.log('todos los Role permission Request',this.permissionRequest)

  }
 
  constructor(public apiService: ApiService) 
  {

  }
  updateRolePerm(){
  
    const aquimelapelas: {
      property1: number,
      property2: number,
      active: boolean
    }[] = []


    console.log('permisionrequiest', this.permissionRequest)

    this.permissionRequest.forEach((element:any) => {
      aquimelapelas.push({
        property1 : element.role,
        property2 : element.permission,
        active : element.active
      })
    });

    console.log('caca', aquimelapelas)

    this.apiService.updateRolePermissions(aquimelapelas).subscribe(x=>
      {
        console.log ('popo',x)
      })
  }
   setCellState(rowIndex: number, colIndex: number, state: boolean): void {
    if (rowIndex >= 0 && rowIndex < this.grid.length && colIndex >= 0 && colIndex < this.grid[rowIndex].length) 
    {
      this.grid[rowIndex][colIndex] = state;
    } 
    else 
    {
      console.error('Índices fuera de rango.');
    }
  }
  ngOnInit(): void {
    this.LoadGrid()
    this.LoadRolePermissionsDataMethod()
  }

  async LoadGrid() {

    //Load headers information
    this.rolePermissionsHeaders = ['id', 'role', 'permission','active'];
    //Loads columns information
    this.rolePermissionsColumns = [
      { key: 'id', header: 'ID' },
      { key: 'role', header: 'Role' },
      { key: 'permission', header: 'Permission' },
      { key: 'active', header: 'Active' },

    ];
  }
  async LoadRolePermissionsDataMethod() {
    if (this.apiService) {
      this.apiService.getRolePermissions()
        .subscribe(
          response => {
            // Este dataSource no es el mismo que el de mat table 
            this.dataSourceRolePermissionsPage = new MatTableDataSource<rolePermissionsTable>(response);

            //p table
            console.log("permissions",response)
            response.forEach((element:any) => {
              
              this.setCellState (element.permission-1,element.role-1,element.active)
            });
            response.forEach((element:rolePermissionsTable) => {
              this.RolePermission.push(element)
              this.permissionRequest.push({...element})
            });
          }
        )
    }
  // async GroupPermissionsByRole(){
  //   const groupByRole = permissions.reduce((acc, { role, permission }) => {
  //     if (!acc[role]) {
  //         acc[role] = [];
  //     }
  //     acc[role].push(permission);
  //     return acc;
  // }, {} as Record<number, number[]>);
  
  // console.log(groupByRole);
  //       }
  }
}