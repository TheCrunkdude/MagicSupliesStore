import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginInputComponent } from './component-login/componentlogin';
import { InputOverviewExample } from './component-input';
import { MaterialModule } from './material.module';
import { NgImageSliderModule } from 'ng-image-slider';
import { componentslider } from './slider-component/componentslider';
import { MainpageComponent } from '../app/mainpage/mainpage-component';
import { MenuComponent } from './componentmenu/menu.component';
import { PrimeNgModule } from './primeng.module';import { GridComponent } from './gridcomponent/gridcomponent';
import { AddOrEditUser } from '../app/models/add-edit-usersmodel';
import { AddEditRolesModel } from '../app/models/add-edit-rolemodel';
import { ConfirmationDialogModel } from '../app/models/confirmation-dialog-model';


@NgModule({
  declarations: [
    componentslider,
    LoginInputComponent,
    InputOverviewExample,
    MainpageComponent,
    MenuComponent,
    GridComponent,
    AddOrEditUser,
    AddEditRolesModel,
    ConfirmationDialogModel,
    
    
  ],
  imports: [
    CommonModule,
    NgImageSliderModule,
    MaterialModule,
    PrimeNgModule,
    
  ],
  exports:[
    componentslider,
    MainpageComponent,
    MenuComponent,
    AddOrEditUser,
    GridComponent,
    MaterialModule,
    PrimeNgModule
  ]
  
})
export class ComponentsModule { }
