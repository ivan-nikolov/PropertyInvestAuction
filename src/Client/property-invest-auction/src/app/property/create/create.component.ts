import { Component} from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Address } from '../../shared/address-select/address';
import { PropertyService } from '../services/property.service';
import { Category } from '../../administration/models/category';
import { CategoryService } from '../../administration/services/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {

  addressSelected: boolean;

  propertyForm: FormGroup;

  categories: Category[];
  address: Address;
  photoImgs: string[] = [];
  photosData: File[] = [];

  constructor(
    private propertyService: PropertyService,
    private categoryService: CategoryService,
    private fb: FormBuilder,
    private router: Router) {

    this.propertyForm = this.fb.group({
      'description': ['', [Validators.required, Validators.minLength(10), Validators.maxLength(50)]],
      'category': ['', [Validators.required]],
      'photos': this.fb.array([''])
    });


    this.photos.clear();

    this.categoryService.loadCategories().subscribe(
      res => this.categories = res
    )
  }

  get photos() {
    return this.propertyForm.get('photos') as FormArray;
  }

  selectAddress(address: Address) {
    this.address = address;
    this.addressSelected = !!this.address.countryId && !!this.address.cityId && !!this.address.id;
  }

  addProperty() {
    const {description, category: categoryId, photos} = this.propertyForm.value;
    
    this.propertyService.create(description, categoryId, this.address.id, photos)
    .subscribe(
      res => {
        this.router.navigate(['property/detail', res.id]);
      }
    )
  }

  onSelectFile(event: any) {
    if (event.target.files && event.target.files[0]) {
      var filesAmount = event.target.files.length;
      for (let i = 0; i < filesAmount; i++) {
        var reader = new FileReader();
        this.photos.push(this.fb.control(event.target.files[i]));
        
        reader.onload = (event: any) => {
          this.photoImgs.push(event.target.result);
        }
        reader.readAsDataURL(event.target.files[i]);
      }
    }
  }
}
