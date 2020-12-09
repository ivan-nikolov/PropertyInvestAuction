import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { cityAsyncValidator, countryAsyncValidator, neighborhoodAsyncValidator } from '../async-validators';
import { City } from '../models/city';
import { Country } from '../models/country';
import { NeighborhoodInput } from '../models/neighborhood-input';
import { LocationService } from '../services/location.service';

export interface AddLocationData {
  countries: Country[]
}

@Component({
  selector: 'app-add-location',
  templateUrl: './add-location.component.html',
  styleUrls: ['./add-location.component.css']
})
export class AddLocationComponent implements OnInit {

  countryForm: FormGroup;
  cityForm: FormGroup;
  neighborhoodForm: FormGroup;

  countries: Country[];
  cities: City[];

  controls = {
    countryName: () => this.countryForm?.controls['name'],
    cityName: () => this.cityForm?.controls['name'] as FormControl,
    countrySelect: () => this.cityForm?.controls['countrySelect'] as FormControl,
    countryId: () => this.neighborhoodForm?.controls['countryId'] as FormControl,
    cityId: () => this.neighborhoodForm?.controls['cityId'] as FormControl,
    neighborhoodName: () => this.neighborhoodForm?.controls['name'] as FormControl,
  }
  
  constructor(
    public dialogRef: MatDialogRef<AddLocationComponent>,
    private fb: FormBuilder,
    private locationService: LocationService,
    private snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: AddLocationData
    ) {  }

    ngOnInit() {
      this.countries = this.data.countries,
      this.createCountryForm();
      this.createCityForm();
      this.createNeighborhoodForm();
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

  loadCities(countryId: string){
    console.log(this.controls.countryId().value);
    this.locationService.loadCitiesByCountryId(countryId).subscribe(
      res => {
        this.cities = res;
      }
    )
  }

  addCountry(formDirective: FormGroupDirective){
    this.locationService.addCountry(this.countryForm.value).subscribe(
      res => {
      formDirective.resetForm();
      this.openSnackBar('Country created');
      this.createCountryForm();
    });
  }

  addCity(formDirective: FormGroupDirective) {
    this.locationService.addCity({countryId: this.controls.countrySelect().value, name: this.controls.cityName().value}).subscribe(
      res => {
        formDirective.resetForm();
        this.openSnackBar('City created');
        this.createCityForm();
      }
    )
  }
  
  addNeighborhood(formDirective: FormGroupDirective) {
    const neighborhood: NeighborhoodInput = {
      cityId: this.controls.cityId().value,
      name: this.controls.neighborhoodName().value,
    } 
    this.locationService.addNeighborhood(neighborhood).subscribe(
      res => {
        formDirective.resetForm();
        this.openSnackBar('Neighborhood created');
        this.createNeighborhoodForm();
      }
    )
  }
  
  private createCountryForm() {
    this.countryForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)], [countryAsyncValidator(this.locationService)]]
    });
  }

  private createCityForm() {
    this.cityForm = this.fb.group({
      countrySelect: ['', [Validators.required]],
      name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)], [cityAsyncValidator(this.locationService)]]
    })
  }

  private createNeighborhoodForm() {
    this.neighborhoodForm = this.fb.group({
      countryId: ['', [Validators.required]],
      cityId: ['', [Validators.required]],
      name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)], [neighborhoodAsyncValidator(this.locationService)]]
    })
  }

  private openSnackBar(message: string) {
    this.snackBar.open(message, '', {
      duration: 3000,
    }) 
  }
}
