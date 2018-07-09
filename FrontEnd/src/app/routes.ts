import { AmigoComponent } from './amigo/amigo.component';
import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { AuthGuard } from './auth/auth.guard';
import { ForbiddenComponent } from './forbidden/forbidden.component';


export const appRoutes: Routes = [
  {
      path: 'home',
      component: HomeComponent,
      canActivate: [AuthGuard]
  },
  {
    path: 'amigo',
    component: AmigoComponent,
    canActivate: [AuthGuard]
},
  { path: 'forbidden', component: ForbiddenComponent, canActivate: [AuthGuard] },
  {
    path: 'login',
    component: UserComponent,
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
}
];
