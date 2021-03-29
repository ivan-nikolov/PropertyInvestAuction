import { Component, Input, OnInit } from '@angular/core';
import { Property } from '../../property/models/property'

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.css']
})
export class PropertyCardComponent {

  @Input() property: Property;
  
  constructor() { }

}
