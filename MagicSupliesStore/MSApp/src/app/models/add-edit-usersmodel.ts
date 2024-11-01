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
    data: {valueFromInput: string}[]=[
    ]

    fieldData:{key:number, fieldname:string, _value:string}[] =[
    ]

    InputData = model(this.data);
    dialogData : any;
    isEdit: boolean = false;

 
    constructor(@Inject(MAT_DIALOG_DATA) public matDialogData: any,){

      this.dialogData = matDialogData
      
    }

    inputSelect(event: any) {
      //Creates the Signal with the Internal values
      console.log(this.inputComponents)
      this.inputComponents.forEach(element => {
        this.data.push({valueFromInput:element.valuefromInput})

      });      
      //Sets the signal  
      this.InputData.set(this.data)
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
        console.log('ngonInit ==>', this.dialogData)

        this.dialogData.modalData.forEach((element:  { key: number, columnName: any; value: any, isModal: any })  => {
          if (element.isModal){
            this.fieldData.push ({key:counter, fieldname: element.columnName, _value: element.value})
          counter = counter+1
          }

      });
      console.log('inputcomponents ==>', this.inputComponents)

      console.log('Value from data',this.data)
      this.isEdit = this.dialogData.isEdit

      console.log('==> Dialog parent data: ', this.dialogData)

    }
  }
  
  
  