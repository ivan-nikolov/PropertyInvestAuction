import { Component, OnInit } from '@angular/core';
import { PropertyService } from '../services/property.service';
import { Property } from '../models/property';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  property: Property;

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute,
    private location: Location, ) { }

  ngOnInit(): void {
    var id = String(this.route.snapshot.paramMap.get('id'));
    this.propertyService.getById(id)
      .subscribe(
        res => {
          this.property = res;
        }
      );
  }

  onBackClicked() {
    this.location.back();
  }
}
