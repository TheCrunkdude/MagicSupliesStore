import { Component, EventEmitter, Input, OnInit, Output, ɵgetLocaleCurrencyCode} from '@angular/core';
import { UserTable } from '../../app/interfaces/userTable-interface';
import { ApiService } from '../../services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { emit } from 'process';

@Component({
  selector: 'app-gridcomponent',
  templateUrl: './gridcomponent.html',
  styleUrl: './gridcomponent.css'
})

export class GridComponent implements OnInit{
  
fechaDummy: Date=new Date();

displayedColumns: string[] = ['ID','UserName','Password','RoleID','Mail','CreationDate','Actions'];

@Input () dataSourceGridInput : any;

@Output() gridSelected = new EventEmitter<string>();


SelectGridEvent(id: any){
  this.gridSelected.emit(id)
  
}

ngOnInit(): void {
}
}
