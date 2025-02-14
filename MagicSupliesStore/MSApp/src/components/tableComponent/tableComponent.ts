import { Component, EventEmitter, Input, OnInit, Output, input, ɵgetLocaleCurrencyCode } from '@angular/core';

@Component({
    selector: 'app-tablecomponent',
    templateUrl: './tablecomponent.html',
    styleUrl: './tablecomponent.css'
})


export class TableComponent implements OnInit {

    @Input() dataSourceInput: any;
    @Input() columns: string[] = [];
    @Input() rows: string[] = [];
    @Input() grid: boolean[][] = [];
    @Input() isChecked: any;
    @Input() tableType: string = '';
    checkboxType: boolean = false;
    defaultType: boolean = false;
    @Output() detectChangeEvent = new EventEmitter<any>();


    constructor() {
    }

    ngOnInit()
    {
        console.log ('tabletype',this.tableType)
        this.defineTableType(this.tableType)
    }
    changeDetector(rowIndex:number, colIndex:number, event:any){
        const eventReFormat = { rowIndex: rowIndex, colIndex: colIndex, active: event.checked, }
        this.detectChangeEvent.emit(eventReFormat)
        console.log('checked en change detector',eventReFormat)
    }

    defineTableType(tableType: string) {
        switch (tableType) {
            case "checkboxType":
                this.checkboxType = true
                break;
                case "defaultType":
                this.defaultType = true
                break;
            default:
                this.defaultType = true
                break;
        }

    }
}

