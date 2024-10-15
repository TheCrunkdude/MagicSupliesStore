import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
    selector: 'input-overview-example',
    styles: `
  .example-form {
  min-width: 150px;
  max-width: 500px;
  height:  100px;
  width: 100%;
}

.example-full-width {

  width: 80%;
  margin: 10%; 
}`,

    template: `<form class="example-form">
  <mat-form-field class="example-full-width">
    <mat-label>{{field}}</mat-label>
    <input (input)="onChange($event)" matInput placeholder={{placeholder}} value={{valuefromInput}}>
  </mat-form-field>
</form>`,

})
export class InputOverviewExample implements OnInit{ 

    @Input () field : string = '';
    @Input () placeholder : string = '';
    @Output() inputSelected = new EventEmitter<string>();

    valuefromInput : string = '';
   
    onChange(event: Event): void {

      //retrieves the value from the htmltextbox and updates the internal variable
      var inputString = (event.target as HTMLTextAreaElement).value
      this.valuefromInput = inputString
      //emits the event for the selected value
      this.inputSelected.emit(this.valuefromInput)
      console.log('Input LEVEL value => ' + this.valuefromInput)
    }
    
    ngOnInit(): void {
    }
    
    
}