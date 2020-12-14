import { Component, OnChanges, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Address } from '../../shared/address-select/address';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  addressSelected: boolean;

  propertyForm: FormGroup;

  address: Address;

  constructor() { }

  ngOnInit(): void {
    
  }

  selectAddress(address: Address) {
    this.address = address;
    this.addressSelected = !!this.address.countryId && !!this.address.cityId && !! this.address.id;
  }
}
