import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { MainpageComponent } from './mainpage/mainpage-component';
import { UsersComponent } from './users/users.component';

export const routes: Routes = [
    {path: "home", component:AppComponent },
    {path: "", component:AppComponent },
    {path: "MainPage", component:MainpageComponent},
    {path: "Users", component:UsersComponent}
//    {path: "**", component:NotFoundStatusComponent} //
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }