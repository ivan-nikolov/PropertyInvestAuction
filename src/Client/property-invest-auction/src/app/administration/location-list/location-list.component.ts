import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddLocationComponent } from '../add-location/add-location.component';
import { EditLocationComponent } from '../edit-location/edit-location.component';
import { City } from '../models/city';
import { Country } from '../models/country';
import { Neighborhood } from '../models/neighborhood';
import { LocationService } from '../services/location.service';
import { EditDialogData } from '../models/edit-dialg-data'
 


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

  openAddDialog(): void {
    const addDialogRef = this.dialog.open(AddLocationComponent, {
      width: '700px',
      height: '600px',
      data: {
        countries: this.countries,
      }
    });

    addDialogRef.afterClosed().subscribe(result => {
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
      this.countries.filter(c => c.id === countryId)[0].cities = data;
    })   
  
  }

  loadNeighborhoods(cityId: string, countryId: string) {
    var city = this.countries.filter(c => c.id === countryId)[0].cities.filter(c => c.id === cityId)[0];
    this.locationService.loadNeighborhoods(cityId).subscribe(
      data => {
        city.neighborhoods = data;
      }
    )
  }

  editCountry(id: string, name: string) {
    const editCountryDialog = this.operEditDialog(name, 'country');

    editCountryDialog.afterClosed().subscribe(
      res => {
        if(res && res.valid){
          this.locationService.editCountry(id, res.name).subscribe(
            res => {
              this.loadCountries();
            })
        }
      }
    )
  }

  deleteCountry(id: string) {
    this.locationService.deleteCountry(id).subscribe(
      res => this.loadCountries()
    )
  }

  editCity(city: City) {
    const editCityDialog = this.operEditDialog(city.name, 'city');

    editCityDialog.afterClosed().subscribe(
      res => {
        if(res && res.valid){
          this.locationService.editCity(city.id, res.name).subscribe(
            res => {
              this.loadCities(city.countryId);
            })
        }
      }
    )
  }

  deleteCity(city: City) {
    this.locationService.deleteCity(city.id).subscribe(
      res => this.loadCities(city.countryId)
    )
  }

  editNeighborhood(id: string, name: string, city: City) {
    const editDialog = this.operEditDialog(name, 'neighborhood');
    editDialog.afterClosed().subscribe(
      res => {
        console.log(res);
        if(res && res.valid){
          this.locationService.editNeighborhood(id, res.name).subscribe(
            res => {
              this.loadNeighborhoods(city.id, city.countryId);
            })
        }
      }
    )
  }

  deleteNeighborhood(neighborhood: Neighborhood, countryId: string) {
    this.locationService.deleteNeighborhood(neighborhood.id).subscribe(
      res => this.loadNeighborhoods(neighborhood.cityId, countryId)
    )
  }

  private operEditDialog(name: string, control: string) {

    const data: EditDialogData = {
      control: control,
      name: name,
      valid: false
    }

    return this.dialog.open(EditLocationComponent, {
      width: '500px',
      height: '300px',
      data : data
    });
  }

}
