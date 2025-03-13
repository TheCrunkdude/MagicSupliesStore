import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AppRoutingModule } from './app.routes';
import { ComponentsModule } from '../components/components.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { UsersPageComponent } from './users-page/userspage.component';
import { LoginpageComponent } from './login-page/loginpage';
import { RolesPageComponent } from './roles-page/roles.component';
import { PermissionsPageComponent } from './permissions-page/permissions.component';
import { RolePermissionsPageComponent } from './rolePermissions-Page/rolePermissions.component';
import { TableComponent } from '../components/tableComponent/tableComponent';
import { UserRolesPageComponent } from './userRoles-Page/userRoles.component';
import { AuthInterceptor } from '../services/auth.Interceptor';
import { ErrorInterceptor } from '../services/error.interceptor';
import { ErrorComponent } from './error_page/error-page';
import { BeerPageComponent } from './beer_page/beer-page';
import { PaginatorComponent } from '../components/paginator-table/paginator-table.component';


@NgModule({
  declarations: [
    AppComponent,
    UsersPageComponent,
    LoginpageComponent,
    RolesPageComponent,
    PermissionsPageComponent,
    RolePermissionsPageComponent,
    UserRolesPageComponent,
    TableComponent,
    ErrorComponent,
    BeerPageComponent,
    PaginatorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ComponentsModule,
    HttpClientModule,
    
  ],
  providers: [
    provideAnimationsAsync(),
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }