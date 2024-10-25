import {Component, Inject, inject, model, OnInit, signal, ViewChild}from '@angular/core';
import { UserTable } from '../../app/interfaces/userTable-interface';
import { MAT_DIALOG_DATA, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { InputOverviewExample } from '../../components/component-input';

export interface DialogData {
  valueFromInput1: string;
  valueFromInput2: string;
  valueFromInput3: string;
  valueFromInput4: string;
}

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
    
    @ViewChild('inputComponent1') inputComponent1 !: InputOverviewExample;
    @ViewChild('inputComponent2') inputComponent2 !: InputOverviewExample;
    @ViewChild('inputComponent3') inputComponent3 !: InputOverviewExample;
    @ViewChild('inputComponent4') inputComponent4 !: InputOverviewExample;

    readonly dialogRef = inject(MatDialogRef<AddOrEditUser>);
    data: DialogData = {
      valueFromInput1: '',
      valueFromInput2: '',
      valueFromInput3: '',
      valueFromInput4: ''

    };
    fieldData:{field1:string,field2:string,field3:string,field4:string} ={
      field1:'User Name', 
      field2: 'Pasword',
      field3: 'Pasword',
      field4: 'Pasword'

    }

    InputData = model(this.data);
    dialogData : any;
    isEdit: boolean = false;

 
    constructor(@Inject(MAT_DIALOG_DATA) public matDialogData: any,){

      this.dialogData = matDialogData

    }

    inputSelect(event: any) {
      //Creates the Signal with the Internal values
      this.data.valueFromInput1 = this.inputComponent1.valuefromInput,
      this.data.valueFromInput2= this.inputComponent2.valuefromInput,
      this.data.valueFromInput3= this.inputComponent3.valuefromInput,
      this.data.valueFromInput4= this.inputComponent4.valuefromInput

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
      
      this.data.valueFromInput1= this.dialogData.UserName
      this.data.valueFromInput2= this.dialogData.Password
      this.data.valueFromInput3=this.dialogData.RoleID
      this.data.valueFromInput4=this.dialogData.Mail
      this.isEdit = this.dialogData.IsEdit

      console.log('==> Dialog parent data: ', this.dialogData)

    }
  }
  
  
  