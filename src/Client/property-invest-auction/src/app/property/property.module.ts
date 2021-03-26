import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PropertyRoutingModule } from './property-routing.module';
import { CreateComponent } from './create/create.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { MyPropertiesComponent } from './my-properties/my-properties.component';



@NgModule({
  declarations: [CreateComponent, MyPropertiesComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    PropertyRoutingModule,
    SharedModule,
    MaterialModule
  ]
})
export class PropertyModule { }
