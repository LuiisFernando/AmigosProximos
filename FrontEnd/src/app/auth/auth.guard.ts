import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../shared/user.service';

import { map, take } from 'rxjs/operators';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private userService: UserService
  ) { }



  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

      // aqui deve estar a logica se o usuário pode acessar a tela ou não através de um modulo de permissão
    // return this.userService.isLoggedIn
    //   .pipe(
    //     take(1),
    //     map((isLoggedIn: boolean) => {
    //       if (!isLoggedIn) {
    //         // this.router.navigate(['/login']);
    //         return false;
    //       }
    //       return true;
    //     })
    //   );
    return true;
  }
}
