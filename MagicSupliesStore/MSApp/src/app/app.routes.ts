import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { MainpageComponent } from './mainpage/mainpage-component';
import { UsersPageComponent } from './users-page/userspage.component';
import { LoginpageComponent } from './login-page/loginpage';
import { RolesPageComponent } from './roles-page/roles.component';
import { PermissionsPageComponent } from './permissions-page/permissions.component';
import { RolePermissionsPageComponent } from './rolePermissions-Page/rolePermissions.component';
import { UserRolesPageComponent } from './userRoles-Page/userRoles.component';
import { AuthGuard } from '../services/auth.guard';
import { ErrorComponent } from './error_page/error-page';
import { BeerPageComponent } from './beer_page/beer-page';

export const routes: Routes = [
    {path: "MainPage", component:MainpageComponent},
    {path: "Users", component : UsersPageComponent, canActivate: [AuthGuard]},
    {path: "", component:LoginpageComponent},
    {path:"Roles", component:RolesPageComponent, canActivate: [AuthGuard], data: { permissions: ['perm 2'] }},
    {path:"Permissions", component:PermissionsPageComponent},
    {path: "RolePermissions", component:RolePermissionsPageComponent},
    {path: "UserRoles", component:UserRolesPageComponent},
    {path: "ErrorPage", component:ErrorComponent},
    {path: 'error', component: ErrorComponent },
    {path: "Beers", component:BeerPageComponent}, //
    {path: "**", component:ErrorComponent} //

  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }