import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Auth {
  private apiUrl = 'https://localhost:7027/gateway/connect/token';
  private tokenKey = 'hms_auth_token';

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const body = new HttpParams()
      .set('grant_type', 'password')
      .set('username', email)
      .set('password', password)
      .set('client_id', 'postman-client');

    const headers = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded'
    });

    return this.http.post(this.apiUrl, body, { headers: headers }).pipe(
      // Use the 'tap' operator to perform a side effect: storing the token
      tap(response => this.storeToken(response))
    );
  }

  // New method to store the token
  private storeToken(response: any) {
    if (response && response.access_token) {
      localStorage.setItem(this.tokenKey, response.access_token);
    }
  }

  // New method to retrieve the token
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  // New method to log out
  logout(): void {
    localStorage.removeItem(this.tokenKey);
    // We will add navigation back to login page later
  }
}
