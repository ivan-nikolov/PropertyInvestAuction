import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PropertyQueryModel } from '../models/property-query-model';
import { Category } from '../../administration/models/category';
import { CategoryService } from '../../administration/services/category.service';
import { Address } from '../../shared/address-select/address';
import { debounceTime, distinctUntilChanged, map } from 'rxjs/operators';
import { pipe } from 'rxjs';
import { ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-property-search-form',
  templateUrl: './property-search-form.component.html',
  styleUrls: ['./property-search-form.component.css']
})
export class PropertySearchFormComponent implements OnInit {

  @Output() propertyEvent = new EventEmitter<PropertyQueryModel>();
  
  categories: Category[];
  address: Address;

  propertyQueryForm: FormGroup;

  constructor(private fb: FormBuilder, private categoryService: CategoryService) {
    
  }

  ngOnInit(): void {
    this.categoryService.loadCategories()
      .subscribe(res => {
        this.categories = res
      });

      this.propertyQueryForm = this.fb.group({
        'description': [''],
        'categoryId': [''],
      });
      
    this.propertyQueryForm.valueChanges.pipe(
      map<any, { description: string, categoryId: string, }>(x => x),
      debounceTime(200),
      distinctUntilChanged((a, b) => a.description === b.description && a.categoryId === b.categoryId)
      )
      .subscribe(
        res => {
          this.setPropertyQuery();
        }
      )
  }

  setPropertyQuery() {
    var propertyQuery : PropertyQueryModel = {
      description: this.propertyQueryForm.controls['description'].value,
      categoryId: this.propertyQueryForm.controls['categoryId'].value,
      countryId: this.address?.countryId || '',
      cityId: this.address?.cityId || '',
      neighborhoodId: this.address?.neighborhoodId || '',
      addressId: this.address?.id || '',
      page: 0,
      pageSize: 0
    }
    this.propertyEvent.emit(propertyQuery);
  }

  selectAddress(event: Address): void {
    this.address = event;
    this.setPropertyQuery();
  }

}
