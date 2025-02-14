import { Component, inject, OnInit, ViewChild } from "@angular/core";
import { rolePermissionsTable, rolePermissionsTableFilter } from "../interfaces/rolesPermissionsTable-interface";
import { GridComponent } from "../../components/gridcomponent/gridcomponent";
import { ApiService } from "../../services/api.service";
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from "@angular/material/dialog";
import { PermissionsTable } from "../interfaces/permissionsTable-interface";
import { RolesTable } from "../interfaces/rolesTable-interface";



@Component({
  selector: 'app-rolePermissions',
  templateUrl: './rolePermissions.component.html',
  styleUrl: './rolePermissions.component.css',
})
export class RolePermissionsPageComponent implements OnInit {

  readonly dialog = inject(MatDialog)
  dataSourceRolePermissionsPage: any//cambiar?//
  rolePermissionsColumns: { key: string, header: string }[] = []
  rolePermissionsHeaders: string[] = []
  rows: any[] = []
  columns: any[] = []
  grid: boolean[][] = []
  permissionRequest: rolePermissionsTable[] = []
  rolePermissionsfilter: any[] = []
  mapedRoles: any[] = []
  mapedPerms: any[] = []
  @ViewChild('gridComponent') gridComponent !: GridComponent;

  async toggleChanges(event: any): Promise<void> {
    let result: any; // Declarar la variable fuera del 'if'

    result = { id: 0, roleID: event.colIndex + 1, role: this.mapedRoles[event.colIndex].role, permissionID: event.rowIndex + 1, permission: this.mapedPerms[event.rowIndex].permission, active: event.active }
    if (result) {
      this.permissionRequest = this.permissionRequest.filter(
        (entry: any) =>
          entry.role !== result.role || entry.permission !== result.permission
      );
      this.permissionRequest.push(result)
    }
    else {
      console.log('algo fallo!')
    }
  }

  constructor(public apiService: ApiService) {
  }

  updateRolePerm() {

    const updateRequest: {
      property1: number,
      property2: string,
      property3: number,
      property4: string,
      active: boolean
    }[] = []

    this.permissionRequest.forEach((element: any) => {
      updateRequest.push({
        property1: element.roleID,
        property2: element.role,
        property3: element.permissionID,
        property4: element.permission,
        active: element.active
      })
    });
    this.apiService.updateRolePermissions(updateRequest).subscribe(x => {
      window.location.reload()
    })
  }

  setCellState(rowIndex: number, colIndex: number, state: boolean): void {
    if (rowIndex >= 0 && rowIndex < this.grid.length && colIndex >= 0 && colIndex < this.columns.length) {
      this.grid[rowIndex][colIndex] = state;
    }
    else {
      console.error('Índices fuera de rango.', rowIndex, colIndex);
    }
  }
  ngOnInit(): void {
    this.LoadGrid()
    this.LoadRolePermissionsDataMethod()
  }

  async LoadGrid() {
    //Load headers information
    this.rolePermissionsHeaders = ['role', 'permissions'];
    //Loads columns information
    this.rolePermissionsColumns = [
      { key: 'role', header: 'Role' },
      { key: 'permissions', header: 'Permissions' },
    ];
    //Aqui llenamos los valores de la primera columna, que son los permisos,
    // obteniendolos directamente de la base de datos de permissions
    this.apiService.getPermissions().subscribe(respons => {
      respons = respons.sort((a, b) => a.id - b.id);
      respons.forEach((element: PermissionsTable) => {
        this.mapedPerms.push(element)
        this.rows.push(element.permission)
        this.grid =Array.from({ length: this.rows.length }, () => Array().fill(false))
        console.log("permission", this.mapedPerms)
      }
      )
    })
    this.apiService.getRolesTable().subscribe(respons => {
      respons = respons.sort((a, b) => a.id - b.id);
      respons.forEach((element: RolesTable) => {
        this.mapedRoles.push(element)
        this.columns.push(element.role)
        console.log("columns", this.columns)
      })
    })
  }

  async LoadRolePermissionsDataMethod() {
    if (!this.apiService) return;

    this.apiService.getRolePermissions().subscribe(response => {
      if (!response || response.length === 0) {
        console.warn('No role permissions received.');
        return;
      }

      // Iterar sobre response para setear el estado de las celdas
      response.forEach((element: any) => {
        this.setCellState(element.permissionID - 1, element.roleID - 1, element.active);
      });

      console.log("Role permissions:", response);
  // Agrupar permisos por rol usando reduce()
  const groupedRoles = response.reduce((acc: Record<string, Set<any>>, curr) => {
    if (!acc[curr.role]) {
      acc[curr.role] = new Set(); // Usamos un Set para evitar duplicados
    }
    acc[curr.role].add(curr.permission);
    return acc;
  }, {});
  console.log("Grouped Roles:", groupedRoles);

  // Convertir el objeto agrupado a un array con permisos concatenados
  const result = Object.entries(groupedRoles).map(([role, permissions]) => ({
    role,
    permissions: Array.from(permissions).join(', ') // Convertir Set a string separado por comas
  }));

  console.log('Final grouped result:', result);

  // Guardar en la tabla de datos
  this.dataSourceRolePermissionsPage = new MatTableDataSource<rolePermissionsTableFilter>(result);

});
  
  }
}