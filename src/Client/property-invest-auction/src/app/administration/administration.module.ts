import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationListComponent } from './location-list/location-list.component';
import { EditLocationComponent } from './edit-location/edit-location.component';
import { AddLocationComponent } from './add-location/add-location.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [LocationListComponent, EditLocationComponent, AddLocationComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class AdministrationModule { }
