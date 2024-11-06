import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AppRoutingModule } from './app.routes';
import { FormsModule } from '@angular/forms';
import { ComponentsModule } from '../components/components.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { UsersPageComponent } from './users-page/userspage.component';
import { LoginpageComponent } from './login-page/loginpage';
import { RolesPageComponent } from './roles-page/roles.component';
import { PermissionsPageComponent } from './permissions-page/permissions.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersPageComponent,
    LoginpageComponent,
    RolesPageComponent,
    PermissionsPageComponent
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