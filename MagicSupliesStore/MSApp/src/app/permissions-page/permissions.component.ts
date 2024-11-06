import { Component, inject, OnInit, viewChild, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GridComponent } from '../../components/gridcomponent/gridcomponent';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { PermissionsTable } from '../interfaces/permissionsTable-interface';

@Component ({
    selector:'app-permitions',
    templateUrl:'./permissions.component.html',
    styleUrl:'./permissions.component.css',
})
export class PermissionsPageComponent implements OnInit {

    readonly dialog = inject(MatDialog);
    dataSourcePermissionsPage: any;//cambiar?//
    Permission!: PermissionsTable;
    permissionsColumns: { key: string, header: string}[] = [];
    permissionsHeaders: string[] = [];
    @ViewChild('gridComponent') gridComponent !: GridComponent;

    constructor(public apiService: ApiService) {
    }
    ngOnInit(): void {
        this.LoadGrid()
        this.LoadpermissionsDataMethod()

    }
    async LoadGrid() {

        //Load headers information
        this.permissionsHeaders = ['id', 'permission', 'description', 'actions'];

        //Loads columns information
        this.permissionsColumns = [
            { key: 'id', header: 'ID' },
            { key: 'permission', header: 'Permission ID' },
            { key: 'description', header: 'Role' },
        ];

    }
    
    async LoadpermissionsDataMethod() {
        if (this.apiService) {
          this.apiService.getPermissions()
            .subscribe(
              response => {
                // Este dataSource no es el mismo que el de mat table 
                this.dataSourcePermissionsPage = new MatTableDataSource<PermissionsTable>(response);
              })
        }
    
      }

}