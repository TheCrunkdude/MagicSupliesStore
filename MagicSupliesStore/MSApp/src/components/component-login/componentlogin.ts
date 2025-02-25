import { Component, EventEmitter, inject, Input, model, OnInit, output, Output, signal, viewChild, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { InputOverviewExample } from '../component-input';


export interface DialogData {
  valueFromInput1: string;
  valueFromInput2: string;
}
@Component({
  selector: 'input-login',
  styleUrl: './componentlogin.css',
  templateUrl: './componentlogin.html',
})
export class LoginInputComponent implements OnInit {

  @ViewChild('inputComponent1') inputComponent1 !: InputOverviewExample;
  @ViewChild('inputComponent2') inputComponent2 !: InputOverviewExample;

  readonly dialogRef = inject(MatDialogRef<LoginInputComponent>);
  readonly data: DialogData = {
    valueFromInput1: '',
    valueFromInput2: ''
  };
  InputData = model(this.data);

  inputSelect(event: any) {

    //Creates the Signal with the Internal values
    let InputDataSignal: DialogData = {
      valueFromInput1: this.inputComponent1.valuefromInput,
      valueFromInput2: this.inputComponent2.valuefromInput
    }

    //Sets the signal 
    this.InputData.set(InputDataSignal)

    //you can use the value of the event emitter or the saved value from the child component
     console.log("valueFromInput1 ===> " + this.inputComponent1.valuefromInput + this.inputComponent2.valuefromInput  )
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }


}