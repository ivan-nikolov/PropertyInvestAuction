import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationListComponent } from './location-list/location-list.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddLocationComponent } from './add-location/add-location.component';
import { EditCountryComponent } from './edit-country/edit-country.component';



@NgModule({
  declarations: [LocationListComponent, AddLocationComponent, EditCountryComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
})
export class LocationModule { }
