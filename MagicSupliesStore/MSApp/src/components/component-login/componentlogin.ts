import { Component, inject, Input, model, OnInit, Output, signal, viewChild, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { InputOverviewExample } from '../component-input';


export interface DialogData {
  animal: string;
  name: string;
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
  readonly data = inject<DialogData>(MAT_DIALOG_DATA);
  readonly animal = model(this.data.animal);



  onNoClick(): void {
    this.dialogRef.close();
  }


    ngOnInit(): void {
    }


}