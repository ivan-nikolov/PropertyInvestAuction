import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Property } from '../models/property';
import { PropertyQueryModel } from '../models/property-query-model';
import { PropertyService } from '../services/property.service';

@Component({
  selector: 'app-my-properties',
  templateUrl: './my-properties.component.html',
  styleUrls: ['./my-properties.component.css']
})
export class MyPropertiesComponent implements OnInit {

  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  
  propertyQuery: PropertyQueryModel;
  properties: Observable<Property[]>;
  constructor(
    private propertyService: PropertyService
    ) { }

  ngOnInit(): void {
    this.propertyQuery = {
      description: '',
      categoryId: '',
      countryId: '',
      cityId: '',
      neighborhoodId: '',
      addressId: '',
      page: 0,
      pageSize: 0
    }
    this.propertyService.getCount()
    .subscribe(res => {
      this.paginator.length = res;
    });
    this.loadProperties(0, 5);
  }

  loadProperties(pageIndex: number, pageSize: number) {
    this.propertyQuery.page = pageIndex + 1;
    this.propertyQuery.pageSize = pageSize;
    this.properties = this.propertyService.getAll(this.propertyQuery);
    
  }

  setQueryParams(event: PropertyQueryModel) {
    this.propertyQuery = event;
    this.loadProperties(this.paginator.pageIndex, this.paginator.pageSize);
  }
}
