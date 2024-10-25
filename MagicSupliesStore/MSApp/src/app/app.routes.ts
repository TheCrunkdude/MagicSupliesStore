import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { MainpageComponent } from './mainpage/mainpage-component';
import { UsersPageComponent } from './users-page/userspage.component';
import { LoginpageComponent } from './login-page/loginpage';
import { RolesPageComponent } from './roles-page/roles.component';
import { PermissionsPageComponent } from './permissions-page/permissions.component';

export const routes: Routes = [
    {path: "MainPage", component:MainpageComponent},
    {path: "Users", component:UsersPageComponent},
    {path: "", component:LoginpageComponent},
    {path:"Roles", component:RolesPageComponent},
    {path:"Permissions", component:PermissionsPageComponent}
//    {path: "**", component:NotFoundStatusComponent} //
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }