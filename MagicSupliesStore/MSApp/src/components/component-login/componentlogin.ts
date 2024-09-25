import { Component, inject, Input, model, OnInit, signal } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


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
  readonly dialogRef = inject(MatDialogRef<LoginInputComponent>);
  readonly data = inject<DialogData>(MAT_DIALOG_DATA);
  readonly animal = model(this.data.animal);

  onNoClick(): void {
    this.dialogRef.close();
  }
    @Input() field1: string = '';
    @Input() placeholder: string = '';


    ngOnInit(): void {
        console.log(this.placeholder);
        console.log('popo');
    }


}