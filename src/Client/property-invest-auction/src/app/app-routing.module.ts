import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { UserAuthGuard } from './user/services/userAuth.guard';

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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
