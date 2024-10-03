import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { MainpageComponent } from './mainpage/mainpage-component';

export const routes: Routes = [
    {path: "home", component:AppComponent },
    {path: "", component:AppComponent },
    {path: "MainPage", component:MainpageComponent},
    {path: "app-root", component:AppComponent},
//    {path: "**", component:NotFoundStatusComponent} //
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }