import {Component, Inject, inject, model, OnInit, QueryList, signal, ViewChild, ViewChildren}from '@angular/core';
import { UserTable } from '../../app/interfaces/userTable-interface';
import { MAT_DIALOG_DATA, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { InputOverviewExample } from '../../components/component-input';
import e from 'express';



@Component({
    selector: 'add-edit-usersmodel',
    templateUrl: './add-edit-usersmodel.html',
    styles: `
      .boton{
        margin:auto;
        margin-bottom: 10px,
        width: 500px,
      }`
  })
  export class AddOrEditUser implements OnInit {
    
    @ViewChildren('inputComponent') inputComponents: QueryList<InputOverviewExample>
    = new QueryList<InputOverviewExample>();

    readonly dialogRef = inject(MatDialogRef<AddOrEditUser>);
    data: {valueFromDialog: string}[]=[
    ]

    fieldData:{key:number, fieldname:string, _value:string}[] =[
    ]

    dialogData : any;
    isEdit: boolean = false;

 
    constructor(@Inject(MAT_DIALOG_DATA) public matDialogData: any,){

      this.dialogData = matDialogData
      
    }

    inputSelect(event: any) {
      //Creates the Signal with the Internal values
      this.data = []
      this.inputComponents.forEach(element => {
        this.data.push({valueFromDialog:element.valuefromInput})
      });      
    }
  

    onNoClick(): void {
      this.dialogRef.close();
    }

    Close()
    {
      this.dialogRef.close(this.data);
    }

    ngOnInit(): void {
        let counter = 1;
        this.isEdit =this.dialogData.isEdit;

        this.dialogData.modalData.forEach((element:  { key: number, columnName: any; value: any, isModal: any })  => {
          if (element.isModal){
            this.fieldData.push ({key:counter, fieldname: element.columnName, _value: element.value})
          counter = counter+1
          }

      });
      this.isEdit = this.dialogData.isEdit


    }
  }
  
  
  