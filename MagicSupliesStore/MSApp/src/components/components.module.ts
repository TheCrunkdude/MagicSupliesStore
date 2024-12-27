import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginInputComponent } from './component-login/componentlogin';
import { InputOverviewExample } from './component-input';
import { MaterialModule } from './material.module';
import { NgImageSliderModule } from 'ng-image-slider';
import { componentslider } from './slider-component/componentslider';
import { MainpageComponent } from '../app/mainpage/mainpage-component';
import { MenuComponent } from './componentmenu/menu.component';
import { PrimeNgModule } from './primeng.module';
import { UsersPageComponent } from '../app/users-page/userspage.component';
import { LoginpageComponent } from '../app/login-page/loginpage';
import { UserTable} from '../app/interfaces/userTable-interface';
import { GridComponent } from './gridcomponent/gridcomponent';
import { AddOrEditUser } from '../app/models/add-edit-usersmodel';
import { AddEditRolesModel } from '../app/models/add-edit-rolemodel';


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
