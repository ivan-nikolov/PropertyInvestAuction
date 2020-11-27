import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {UserModule} from './user/user.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { CoreModule } from './core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from './user/services/user.service';
import { HttpClientModule } from '@angular/common/http';
import { UserAuthGuard } from './user/services/userAuth.guard';
import { JwtService } from './user/services/jwt.service';
import { RoleGuard } from './user/services/role.guard';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    UserModule,
    CoreModule,
    HttpClientModule
  ],
  providers: [UserService, UserAuthGuard, JwtService, RoleGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
