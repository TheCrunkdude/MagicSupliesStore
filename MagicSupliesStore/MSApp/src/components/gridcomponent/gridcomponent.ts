import { Component, EventEmitter, Input, OnInit, Output, ɵgetLocaleCurrencyCode} from '@angular/core';

@Component({
  selector: 'app-gridcomponent',
  templateUrl: './gridcomponent.html',
  styleUrl: './gridcomponent.css'
})

export class GridComponent implements OnInit{
  
fechaDummy: Date=new Date();

displayedColumns: string[] = ['ID','UserName','Password','RoleID','Mail','CreationDate','Actions'];

@Input () dataSourceGridInput : any;

@Output() buttonEditSelected = new EventEmitter<any>();
@Output() buttonDeleteSelected = new EventEmitter<any>();


SelectEditButtonEvent(element: any){
  this.buttonEditSelected.emit(element)
  
}
SelectDeleteButtonEvent (element: any){
this.buttonDeleteSelected.emit(element)
}

ngOnInit(): void {
}
}
