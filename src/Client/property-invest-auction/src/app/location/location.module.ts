import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationListComponent } from './location-list/location-list.component';
import { MaterialModule } from '../material/material.module';



@NgModule({
  declarations: [LocationListComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
})
export class LocationModule { }
