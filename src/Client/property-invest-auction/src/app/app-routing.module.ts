import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LocationListComponent } from './administration/location-list/location-list.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { RoleGuard } from './user/services/role.guard';
import { UserAuthGuard } from './user/services/userAuth.guard';
import { UserListComponent } from './user/user-list/user-list.component';
import { CategoriesListComponent } from './administration/categories-list/categories-list.component';
import { NotFoundComponent } from './core/not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
    
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [UserAuthGuard],
    data: {
      isAuthenticated: false,
    }
  },
  {
    path: 'register',
    component: RegisterComponent,
    canActivate: [UserAuthGuard],
    data: {
      isAuthenticated: false,
    }
  },
  {
    path: 'user/all',
    component: UserListComponent,
    canActivate: [UserAuthGuard, RoleGuard],
    data: {
      isAuthenticated: true,
      expectedRole: 'Administrator'
    }
  },
  {
    path: 'location',
    component: LocationListComponent,
    canActivate: [UserAuthGuard, RoleGuard],
    data: {
      isAuthenticated: true,
      expectedRole: 'Administrator'
    }
  },
  {
    path: 'categories',
    component: CategoriesListComponent,
    canActivate: [UserAuthGuard, RoleGuard],
    data: {
      isAuthenticated: true,
      expectedRole: 'Administrator'
    }
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
