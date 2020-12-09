import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { cityAsyncValidator, countryAsyncValidator, neighborhoodAsyncValidator } from '../async-validators';
import { EditDialogData } from '../models/edit-dialg-data';
import { LocationService } from '../services/location.service';

interface StringMap { [key: string]: any; };

@Component({
  selector: 'app-edit-country',
  templateUrl: './edit-location.component.html',
  styleUrls: ['./edit-location.component.css', '../../shared/dialog-form-styles.css']
})
export class EditLocationComponent {

  form: FormGroup;


  asyncValidatorsMap: StringMap = {
    'country': countryAsyncValidator,
    'city': cityAsyncValidator,
    'neighborhood': neighborhoodAsyncValidator
  }

  constructor(
    public dialogRef: MatDialogRef<EditLocationComponent>,
    private fb: FormBuilder,
    private locationService: LocationService,
    @Inject(MAT_DIALOG_DATA) public data: EditDialogData) {
    this.form = this.fb.group({
      name: [data.name, [Validators.required, Validators.minLength(2), Validators.maxLength(50)], [this.asyncValidatorsMap[data.control](this.locationService)]]
    })
   }
  
  onCancelClick(): void {
    this.dialogRef.close({valid: false});
  }

  onSubmit(): void {
    this.dialogRef.close({name: this.form.controls['name'].value, valid: this.form.valid});
  }
}

