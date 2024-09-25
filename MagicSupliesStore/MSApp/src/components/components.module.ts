import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginInputComponent } from './component-login/componentlogin';
import { InputOverviewExample } from './component-input';
import { MaterialModule } from './material.module';



@NgModule({
  declarations: [
    LoginInputComponent,
    InputOverviewExample
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class ComponentsModule { }
