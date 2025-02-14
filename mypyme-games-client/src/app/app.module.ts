import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';

@NgModule({

  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes), // Carga las rutas desde app.routes.ts
    AppComponent 
  ],
  bootstrap: []
})
export class AppModule { }

