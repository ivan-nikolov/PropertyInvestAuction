import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocationListComponent } from './location-list/location-list.component';
import { EditLocationComponent } from './edit-location/edit-location.component';
import { AddLocationComponent } from './add-location/add-location.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { AddCategoryComponent } from './add-category/add-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';



@NgModule({
  declarations: [LocationListComponent, EditLocationComponent, AddLocationComponent, CategoriesListComponent, AddCategoryComponent, EditCategoryComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ]
})
export class AdministrationModule { }
