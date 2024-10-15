import { Component, Input, OnInit, ɵgetLocaleCurrencyCode} from '@angular/core';
import { UserTable } from '../../app/interfaces/userTable-interface';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-gridcomponent',
  templateUrl: './gridcomponent.html',
  styleUrl: './gridcomponent.css'
})

export class GridComponent implements OnInit{
  
fechaDummy: Date=new Date();

displayedColumns: string[] = ['ID','UserName','Password','RoleID','Mail','CreationDate'];

@Input () dataSourceGridInput : any;

ngOnInit(): void {
}
}
