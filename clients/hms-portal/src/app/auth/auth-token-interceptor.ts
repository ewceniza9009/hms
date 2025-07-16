import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Auth } from './auth'; // Our Auth service

export const authTokenInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(Auth);
  const authToken = authService.getToken();

  // If a token exists, clone the request and add the Authorization header
  if (authToken) {
    const authReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authToken}`
      }
    });
    return next(authReq);
  }

  // If no token, proceed with the original request
  return next(req);
};
