import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AddressService } from '../address.service';

export interface AddAddressData {
  cityId: string,
  cityName: string,
  neighborhoodId: string,
  neighborhoodName: string
}

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.css', '../dialog-form-styles.css']
})
export class AddAddressComponent implements OnInit {

  addressForm: FormGroup;

  constructor(
    private snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<AddAddressComponent>,
    private fb: FormBuilder,
    private addressService: AddressService,
    @Inject(MAT_DIALOG_DATA) public data: AddAddressData
  ) { 
    this.addressForm = this.fb.group({
      'cityId': [this.data.cityId],
      'neighborhoodId': [this.data.neighborhoodId],
      'name': ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]]
    })
  }

  ngOnInit(): void {
  }

  onCancelClick(): void {
    this.dialogRef.close();
  }

  addAddress() {
    this.addressService.create(this.addressForm.get('name')?.value, this.data.cityId, this.data.neighborhoodId)
    .subscribe(
      res => {
        this.openSnackBar('Address Created');
        this.dialogRef.close(res);
      }
    );
  }
  
  private openSnackBar(message: string, time: number = 5000) {
    this.snackBar.open(message, 'Done', {
      duration: time,
    });
  }

}
