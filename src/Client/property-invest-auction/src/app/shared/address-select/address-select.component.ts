import { Component, DoCheck, EventEmitter, Input, OnInit, Output} from '@angular/core';
import { Address } from './address';
import { Country } from '../../administration/models/country';
import { LocationService } from '../../administration/services/location.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { City } from '../../administration/models/city';
import { Neighborhood } from '../../administration/models/neighborhood';
import { AddressService } from '../address.service';
import { distinctUntilChanged, map, switchMap, tap } from 'rxjs/operators';
import { timer } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { AddAddressComponent } from '../add-address/add-address.component';

@Component({
  selector: 'app-address-select',
  templateUrl: './address-select.component.html',
  styleUrls: ['./address-select.component.css']
})
export class AddressSelectComponent implements OnInit {

  @Input() required: boolean;
  @Output() addressEvent = new EventEmitter<Address>();

  controls = {
    country: () => this.addressForm?.controls['country'],
    city: () => this.addressForm?.controls['city'],
    neighborhood: () => this.addressForm?.controls['neighborhood'],
    address: () => this.addressForm?.controls['address'],
  }

  countries: Country[];
  cities: City[];
  neighborhoods: Neighborhood[];
  addresses: Address[];
  address: Address;

  private requiredValidator: any;

  addressForm: FormGroup;

  constructor(
    private locationService: LocationService,
    private addressService: AddressService,
    private fb: FormBuilder,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.locationService.loadCountries().subscribe(
      res => this.countries = res
    );

    this.requiredValidator = this.required ? Validators.required : Validators.nullValidator;Validators.nullValidator;

    this.addressForm = this.fb.group({
      'country': ['', [this.requiredValidator]],
      'city': ['', [this.requiredValidator]],
      'neighborhood': [''],
      'address': ['', [this.requiredValidator]]
    });

    this.addressForm.valueChanges
    .pipe(
      map<any, {country: string, city: string, neighborhood: string, address: string}>(x => x),
      distinctUntilChanged((a, b) => a.country === b.country && a.city == b.city && a.neighborhood === b.neighborhood && a.address === b.address)
    )
    .subscribe(
      res => {
          this.setOutput();
      }
    )
  }

  loadCities(countryId: string) {

    this.controls.city().setValue('');
    this.controls.neighborhood().setValue('');
    this.controls.address().setValue('');

    this.locationService.loadCitiesByCountryId(countryId).subscribe(
      res => {
        this.cities = res;
      }
    )
  }

  createAddress() {

    const cityId = this.controls.city()?.value || '';
    const cityName = this.cities?.filter(c => c.id == cityId)[0]?.name;
    const neighborhoodId = this.controls.neighborhood()?.value || '';
    const neihborhoodName = this.neighborhoods?.filter(c => c.id == neighborhoodId)[0]?.name || '';

    const addDialogRef = this.dialog.open(AddAddressComponent, {
      width: '650px',
      height: '400px',
      data: {
        cityId: cityId,
        cityName: cityName,
        neighborhoodId: neighborhoodId,
        neighborhoodName: neihborhoodName
      }
    });

    addDialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if(result) {
        this.addresses.push(result);
        this.addressForm.patchValue({'address': result.id}, {emitEvent: true})
      }
    });
  }

  loadNeighborhoods(cityId: string) {

    this.controls.neighborhood().setValue('');
    this.controls.address().setValue('');

    this.locationService.loadNeighborhoods(cityId).subscribe(
      res => this.neighborhoods = res
    )
  }

  loadAddresses(cityId: string, neighborhoodId: string) {

    this.controls.address().setValue('');

    this.addressService.loadAddresses(cityId, neighborhoodId).subscribe(
      res => this.addresses = res
    );
  }

  setOutput() {
    const addressId = this.controls.address().value || '';
    const addressName = this.addresses?.filter(a => a.id == addressId)[0]?.name || '';
    const countryId = this.controls.country()?.value || '';
    const countryName = this.countries?.filter(c => c.id == countryId)[0]?.name || '';
    const cityId = this.controls.city()?.value || '';
    const cityName = this.cities?.filter(c => c.id == cityId)[0]?.name;
    const neighborhoodId = this.controls.neighborhood()?.value || '';
    const neihborhoodName = this.neighborhoods?.filter(c => c.id == neighborhoodId)[0]?.name || '';

    this.address = {
      countryName: countryName,
      countryId: this.controls.country().value,
      cityName: cityName,
      cityId: this.controls.city().value,
      neighborhoodName: neihborhoodName,
      neighborhoodId: this.controls.neighborhood().value,
      id: addressId,
      name: addressName || '',
    }

    this.addressEvent.emit(this.address);
  }
}
