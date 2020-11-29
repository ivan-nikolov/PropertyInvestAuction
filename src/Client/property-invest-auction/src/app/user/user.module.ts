import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { UserListComponent } from './user-list/user-list.component';




@NgModule({
  declarations: [LoginComponent, RegisterComponent, UserListComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ]
})
export class UserModule { }
