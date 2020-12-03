import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddLocationComponent } from '../add-location/add-location.component';
import { Country } from '../models/country';
import { LocationService } from '../services/location.service';
 
const COUNTRIES: Country[] = [
  {id: 'bg', name: 'Bulgaria', cities: []},
  {id: 'de', name: 'Germany', cities: []},
  {id: 'ro', name: 'Romania', cities: []},
]

@Component({
  selector: 'app-location-list',
  templateUrl: './location-list.component.html',
  styleUrls: ['./location-list.component.css']
})
export class LocationListComponent {

  panelOpenState = false;
  countries: Country[];

  constructor(private locationService: LocationService, public dialog: MatDialog) {
    this.loadCountries();
    
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddLocationComponent, {
      width: '700px',
      height: '600px',
      data: {
        countries: this.countries,
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.loadCountries();
    });
  }
  
  loadCountries() {
    this.locationService.loadCountries().subscribe(data => {
        this.countries = data;
    });
  }

  loadCities(countryId: string){
    this.locationService.loadCitiesByCountryId(countryId).subscribe(data => {
      console.log(data);
      this.countries.filter(c => c.id === countryId)[0].cities = data;
    })   
  
  }

  loadNeighborhoods(cityId: string, countryId: string) {
    var city = this.countries.filter(c => c.id === countryId)[0].cities.filter(c => c.id === cityId)[0];
    this.locationService.loadNeighborhoods(cityId).subscribe(
      data => {
        city.neighborhoods = data;
      },
      err=> {
        console.log(err);
      }
    )
  }
}
