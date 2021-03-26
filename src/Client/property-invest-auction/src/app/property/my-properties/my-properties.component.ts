import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
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
  properties: Property[];

  constructor(private propertyService: PropertyService) { }

  ngOnInit(): void {
    
  }

  loadProperties(pageIndex: number, pageSize: number) {
    this.propertyQuery.page = pageIndex;
    this.propertyQuery.pageSize = pageSize;
    console.log(this.propertyQuery);
  }

  setQueryParams(event: PropertyQueryModel) {
    this.propertyQuery = event;
    this.loadProperties(this.paginator.pageIndex, this.paginator.pageSize);
  }
}
