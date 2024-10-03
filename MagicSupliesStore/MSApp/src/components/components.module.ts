import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginInputComponent } from './component-login/componentlogin';
import { InputOverviewExample } from './component-input';
import { MaterialModule } from './material.module';
import { NgImageSliderModule } from 'ng-image-slider';
import { componentslider } from './slider-component/componentslider';
import { MainpageComponent } from '../app/mainpage/mainpage-component';




@NgModule({
  declarations: [
    componentslider,
    LoginInputComponent,
    InputOverviewExample,
    MainpageComponent
    
  ],
  imports: [
    CommonModule,
    NgImageSliderModule,
    MaterialModule,
    
  ],
  exports:[
    componentslider,
    MainpageComponent
  ]
  
})
export class ComponentsModule { }
