import { Component } from '@angular/core';
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
  constructor(private locationService: LocationService) {
    this.locationService.loadCountries().subscribe(data => {
        this.countries = data;
    });
  }

  loadCities(countryId: string){
     this.countries.filter(c => c.id === countryId)[0].cities = [
      {id: 'vn', name: 'Varna', neighborhoods: []},
      {id: 'vn', name: 'Sofia', neighborhoods: []},
      {id: 'vn', name: 'Plovdiv', neighborhoods: []},
      {id: 'vn', name: 'Burgas', neighborhoods: []},
    ]
  }

  loadNeighborhoods(cityId: string, countryId: string) {
    console.log(this.countries.filter(c => c.id === countryId));
    this.countries.filter(c => c.id === countryId)[0].cities.filter(c => c.id === cityId)[0].neighborhoods = [
      {name: 'Levski'},
      {name: 'Troshevo'},
      {name: 'Mladost'},
    ]
  }
}
