import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressSelectComponent } from './address-select/address-select.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { AddAddressComponent } from './add-address/add-address.component';


@NgModule({
  declarations: [AddressSelectComponent, AddAddressComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  exports: [AddressSelectComponent]
})
export class SharedModule { }
