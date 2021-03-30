import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UserModule } from './user/user.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { UserService } from './user/services/user.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserAuthGuard } from './user/services/userAuth.guard';
import { JwtService } from './user/services/jwt.service';
import { RoleGuard } from './user/services/role.guard';
import { TokenInterceptorService } from './user/services/token-interceptor.service';
import { AdministrationModule } from './administration/administration.module';
import { LocationService } from './administration/services/location.service';
import { CategoryService } from './administration/services/category.service';
import { ErrorInterceptorService } from './core/error-interceptor.service';
import { ToastrModule } from 'ngx-toastr';
import { AddressService} from './shared/address.service';
import { PropertyModule } from './property/property.module';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    AdministrationModule,
    BrowserModule,
    CoreModule,
    BrowserAnimationsModule,
    HttpClientModule,
    UserModule,
    PropertyModule,
    ReactiveFormsModule,
    SharedModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    AddressService,
    CategoryService,
    JwtService,
    LocationService,
    RoleGuard,
    UserAuthGuard,
    UserService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
