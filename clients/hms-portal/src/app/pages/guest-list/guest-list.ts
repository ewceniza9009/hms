import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Guest } from '../guest/guest'; // Import our new Guest service

@Component({
  selector: 'app-guest-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './guest-list.html',
  styleUrls: ['./guest-list.scss']
})
export class GuestList implements OnInit { // Implement OnInit

  // Property to hold our list of guests
  public guests: any[] = [];
  public isLoading = true;

  // Inject the Guest service
  constructor(private guestService: Guest) {}

  // ngOnInit is a lifecycle hook that runs when the component is first loaded
  ngOnInit(): void {
    this.guestService.getGuests().subscribe({
      next: (data) => {
        this.guests = data;
        this.isLoading = false;
        console.log('Successfully fetched guests:', data);
      },
      error: (err) => {
        console.error('Failed to fetch guests:', err);
        this.isLoading = false;
      }
    });
  }
}
