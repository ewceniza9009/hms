import { Routes } from '@angular/router';
import { Login } from './auth/login/login';
import { MainLayout } from './layout/main-layout/main-layout';
import { GuestList } from './pages/guest-list/guest-list';
import { authGuard } from './auth/auth-guard';

export const routes: Routes = [
  { path: 'login', component: Login },
  {
    path: '',
    component: MainLayout,
    canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'guests', pathMatch: 'full' },
      { path: 'guests', component: GuestList }
    ]
  },
  { path: '**', redirectTo: '/login' }
];
