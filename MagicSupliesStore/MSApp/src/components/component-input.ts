import { Component, Input, OnInit, Output } from '@angular/core';

@Component({
    selector: 'input-overview-example',
    styles: `
  .example-form {
  min-width: 150px;
  max-width: 500px;
  width: 100%;
}

.example-full-width {
  width: 100%;
}`,

    template: `<form class="example-form">
  <mat-form-field class="example-full-width">
    <mat-label>{{field1}}</mat-label>
    <input (input)="onChange($event)" matInput placeholder={{placeholder}} value={{this.value}}>
  </mat-form-field>

  
</form>`,
})
export class InputOverviewExample implements OnInit{ 

    @Input () field1 : string = '';
    @Input () placeholder : string = '';
    value : string = '';
   
    onChange(event: Event): void {
      var inputString = (event.target as HTMLTextAreaElement).value
      this.value = inputString
      console.log('value => ' + this.value)
    }
    
    ngOnInit(): void {
    }
    
    
}