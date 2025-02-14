import { enableProdMode } from '@angular/core';
import { environment } from './environment/environment';
import { bootstrapApplication } from '@angular/platform-browser';
import { provideServerRendering } from '@angular/platform-server';
import { provideRouter } from '@angular/router';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';
import { serverRoutes } from './app/app.routes.server';

if (environment.production) {
  enableProdMode();
}

bootstrapApplication(AppComponent, {
  providers: [
    provideServerRendering(),
    provideRouter(routes.concat(serverRoutes))
  ]
});
