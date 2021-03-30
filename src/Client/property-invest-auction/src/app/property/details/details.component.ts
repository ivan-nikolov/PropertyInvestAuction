import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertyService } from '../services/property.service';
import { Property } from '../models/property';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  property: Property;

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    var id = String(this.route.snapshot.paramMap.get('id'));
    this.propertyService.getById(id)
      .subscribe(
        res => {
          this.property = res;
        }
      );
  }

}
