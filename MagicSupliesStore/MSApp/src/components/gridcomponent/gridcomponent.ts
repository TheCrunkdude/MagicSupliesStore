import { Component, EventEmitter, Input, OnInit, Output, input, ɵgetLocaleCurrencyCode} from '@angular/core';

@Component({
  selector: 'app-gridcomponent',
  templateUrl: './gridcomponent.html',
  styleUrl: './gridcomponent.css'
})

export class GridComponent implements OnInit{
  
@Input() dataSourceGridInput : any;
@Input() headers: string[] = [];
@Input() columns: { key: string, header: string }[] = [];
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
