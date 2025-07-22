import { Routes } from '@angular/router';

import { LoginComponent } from './auth/login/login.component';

// app-routing.module.ts
export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'app', loadComponent: () => import('../app/app.component').then(a => a.AppComponent) },
  { path: '**', redirectTo: 'login' }
];
