import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AppRoutingModule } from './app.routes';
import { ComponentsModule } from '../components/components.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UsersPageComponent } from './users-page/userspage.component';
import { LoginpageComponent } from './login-page/loginpage';
import { RolesPageComponent } from './roles-page/roles.component';
import { PermissionsPageComponent } from './permissions-page/permissions.component';
import { RolePermissionsPageComponent } from './rolePermissions-Page/rolePermissions.component';
import { TableComponent } from '../components/tableComponent/tableComponent';


@NgModule({
  declarations: [
    AppComponent,
    UsersPageComponent,
    LoginpageComponent,
    RolesPageComponent,
    PermissionsPageComponent,
    RolePermissionsPageComponent,
    TableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ComponentsModule,
    HttpClientModule,
    
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }