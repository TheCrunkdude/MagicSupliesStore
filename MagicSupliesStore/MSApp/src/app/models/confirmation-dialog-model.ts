import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: './confirmation-dialog-model',
  templateUrl: './confirmation-dialog-model.html',
})
export class ConfirmationDialogModel {
  constructor(public dialogRef: MatDialogRef<ConfirmationDialogModel>) {}

  onConfirm(): void {
    // Call the function to log out
    this.dialogRef.close(true);  // Return true if confirmed
  }

  onCancel(): void {
    this.dialogRef.close(false);  // Return false if canceled
  }
}