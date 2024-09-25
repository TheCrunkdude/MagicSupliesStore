import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AppRoutingModule } from './app.routes';
import { FormsModule } from '@angular/forms';
import { ComponentsModule } from '../components/components.module';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [
    
    AppComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ComponentsModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }