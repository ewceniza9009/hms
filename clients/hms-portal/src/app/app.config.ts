import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { FormsModule } from '@angular/forms';
// Import the necessary HttpClient providers and our interceptor
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { authTokenInterceptor } from './auth/auth-token-interceptor';


export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    importProvidersFrom(FormsModule),
    // Update HttpClient provider to use our interceptor
    provideHttpClient(withInterceptors([authTokenInterceptor]))
  ]
};
