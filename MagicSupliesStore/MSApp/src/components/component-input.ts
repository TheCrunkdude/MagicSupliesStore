import { Component, Input, OnInit } from '@angular/core';

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
    <input matInput placeholder={{placeholder}} value={{placeholder}}>
  </mat-form-field>

  
</form>`,
})
export class InputOverviewExample implements OnInit{ 

    @Input () field1 : string = '';
    @Input () placeholder : string = '';
   
    
    ngOnInit(): void {
        console.log(this.placeholder);
        console.log('popo');
    }
    
    
}