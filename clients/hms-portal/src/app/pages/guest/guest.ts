import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Guest { // Class name is Guest
  // URL to the guests endpoint on our gateway
  private apiUrl = 'https://localhost:7027/gateway/guests';

  constructor(private http: HttpClient) { }

  // Method to get all guests
  getGuests(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
