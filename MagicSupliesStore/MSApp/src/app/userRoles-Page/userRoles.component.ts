import { Component, inject, OnInit, ViewChild } from "@angular/core";
import { GridComponent } from "../../components/gridcomponent/gridcomponent";
import { ApiService } from "../../services/api.service";
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from "@angular/material/dialog";
import { RolesTable } from "../interfaces/rolesTable-interface";
import { userRolesTable, userRolesTableFilter } from "../interfaces/userRoles-interface";
import { UserTable } from "../interfaces/userTable-interface";
import * as alertify from 'alertifyjs';

@Component({
    selector: 'app-userRoles',
    templateUrl: './userRoles.component.html',
    styleUrl: './userRoles.component.css',
})
export class UserRolesPageComponent implements OnInit {

    readonly dialog = inject(MatDialog);
    columns: any[] = []
    rows: any[] = []
    grid: boolean[][] = []
    userRolesRequest: userRolesTable[] = []// Cambia esto cuando tengas el tipo User roles hecho
    userRolesFilter: any[] = []
    userRolesHeaders: string[] = []
    userRolesColumns: { key: string; header: string; }[] = []
    mapedUsers: any[] = []
    mapedRoles: any[] = []
    dataSourceUserRolesPage: any;
    @ViewChild('gridComponent') gridComponent !: GridComponent;


    async toggleChanges1(event: any): Promise<void> {
        let result: any; // Declarar e inicializar la variable fuera del 'if'
        result = { id: 0, userID: event.rowIndex + 1, user: this.mapedUsers[event.rowIndex].userName, roleID: event.colIndex + 1, roles: this.mapedRoles[event.colIndex].role, active: event.active }
        if (result) {
            this.userRolesRequest = this.userRolesRequest.filter(
                (entry: any) =>
                    entry.user !== result.user || entry.roles !== result.roles
            );
            this.userRolesRequest.push(result)
        }
        else {
            console.log('algo fallo!')
        }
    }

    updateUserRoles() {
        const updateRequest: {
            property1: number,
            property2: string,
            property3: number,
            property4: string,
            active: boolean
        }[] = []

        this.userRolesRequest.forEach((element: any) => {
            updateRequest.push({
                property1: element.userID,
                property2: element.user,
                property3: element.roleID,
                property4: element.roles,
                active: element.active
            })

        });

        this.apiService.updateUserRoles(updateRequest).subscribe(x => {
            alertify.success(x)
        })
        console.log(" user roles request", this.userRolesRequest)
    }
    async LoadGrid() {
        //Load headers information
        this.userRolesHeaders = ['user', 'roles'];
        //Loads columns information
        this.userRolesColumns = [
            { key: 'user', header: 'User' },
            { key: 'roles', header: 'Roles' },
        ];
        //Aqui llenamos los valores de la primera columna, que son los permisos,
        // obteniendolos directamente de la base de datos de users
        this.apiService.getRolesTable().subscribe(respons => {
            respons = respons.sort((a, b) => a.id - b.id);
            respons.forEach((element: RolesTable) => {
                this.mapedRoles.push(element)
                this.columns.push(element.role)
            })

        })
        this.apiService.getUserTable().subscribe(respons => {
            respons = respons.sort((a, b) => a.ID - b.ID);
            respons.forEach((element: UserTable) => {
                this.mapedUsers.push(element)
                this.rows.push(element.userName)
                this.grid = Array.from({ length: this.rows.length }, () => Array().fill(false))
                console.log("maped users", this.mapedUsers)
            })

        })

    }


    async LoadRolePermissionsDataMethod() {
        if (!this.apiService) return;

        this.apiService.getUserRoles().subscribe(response => {
            if (!response || response.length === 0) {
                console.warn('No role permissions received.');
                return;
            }  
            console.log(" get user roles response ", response)
            // Iterar sobre response para setear el estado de las celdas
            response.forEach((element: any) => {
                this.setCellState(element.userID - 1, element.roleID - 1, element.active);
            });

            console.log("Role permissions:", response);
            // Agrupar permisos por rol usando reduce()
            const groupedRoles = response.reduce((acc: Record<string, Set<any>>, curr) => {
                if (!acc[curr.user]) {
                    acc[curr.user] = new Set(); // Usamos un Set para evitar duplicados
                }
                acc[curr.user].add(curr.role);
                return acc;
            }, {});
            console.log("Grouped Roles:", groupedRoles);

            // Convertir el objeto agrupado a un array con permisos concatenados
            const result = Object.entries(groupedRoles).map(([user, roles]) => ({
                user,
                roles: Array.from(roles).join(', ') // Convertir Set a string separado por comas
            }));

            //   console.log('Final grouped result:', result);

            // Guardar en la tabla de datos
            this.dataSourceUserRolesPage = new MatTableDataSource<userRolesTableFilter>(result);

        });

    }
    setCellState(rowIndex: number, colIndex: number, state: boolean): void {
        if (rowIndex >= 0 && rowIndex < this.grid.length && colIndex >= 0 && colIndex < this.columns.length) {
            this.grid[rowIndex][colIndex] = state;
        }
        else {
            console.error('Índices fuera de rango.', rowIndex, colIndex);
        }
    }


    constructor(public apiService: ApiService) {
    }
    ngOnInit(): void {
        this.LoadGrid()
        this.LoadRolePermissionsDataMethod()       

    }

}
