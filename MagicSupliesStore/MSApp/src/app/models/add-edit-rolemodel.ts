import { Component, Inject, inject, model, OnInit, ViewChild } from "@angular/core";
import { InputOverviewExample } from '../../components/component-input';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";



export interface RolesDialogData {
    valueFromInput1: string;
  }

@Component({
    selector: 'add-edit-rolemodel',
    templateUrl: './add-edit-rolemodel.html',
    styles: `
      .boton{
        margin:auto;
        margin-bottom: 10px,
        width: 500px,
      }`
  })

export class AddEditRolesModel implements OnInit{

  @ViewChild('inputComponent1') inputComponent1 !: InputOverviewExample;
 
  readonly dialogRef = inject(MatDialogRef<AddEditRolesModel>);
    data: RolesDialogData = {
      valueFromInput1: '',
    };
    InputData = model(this.data);
    dialogData : any;
    isEdit: boolean = false;
    
    constructor(@Inject(MAT_DIALOG_DATA) public matDialogData: any,){
      this.dialogData = matDialogData
    }

    inputSelect(event: any) {
      //Creates the Signal with the Internal values
      this.data.valueFromInput1= this.inputComponent1.valuefromInput,
     
      //Sets the signal  
      this.InputData.set(this.data)
    }
      
    onNoClick(): void {
      this.dialogRef.close();
    }

    Close()
    {
      this.dialogRef.close(this.data);
      console.log ('Data on close',this.data)

    }

  ngOnInit(): void {
      
    this.data.valueFromInput1= this.dialogData.Role
    this.isEdit = this.dialogData.IsEdit

    console.log('==> Dialog parent data: ', this.dialogData)

  }
}
