import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivateChild } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class UserAuthGuard implements CanActivate, CanActivateChild {

  constructor (private userService: UserService, private router: Router) {}

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const isAuthenticated = route.data.isAuthenticated;

    if(typeof isAuthenticated === 'boolean' && this.userService.isAuthenticated() === isAuthenticated ){
      return true;
    }

    this.router.navigateByUrl('');
    return false;
  }
  
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const isAuthenticated = route.data.isAuthenticated;

    if(typeof isAuthenticated === 'boolean' && this.userService.isAuthenticated() === isAuthenticated ){
      return true;
    }

    this.router.navigateByUrl('');
    return false;
  }
  
}
