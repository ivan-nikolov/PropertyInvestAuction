import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { categoryNameAsyncValidator } from '../async-validators';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service'

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css', '../../shared/dialog-form-styles.css']
})
export class EditCategoryComponent implements OnInit {

  categoryForm: FormGroup;

  constructor(
    private snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<EditCategoryComponent>,
    private fb: FormBuilder,
    private categoryService: CategoryService,
    @Inject(MAT_DIALOG_DATA) public data: Category
  ) { }

  ngOnInit(): void {
    this.categoryForm = this.fb.group({
      'name': [this.data.name, [Validators.required, Validators.minLength(4), Validators.maxLength(50)], [categoryNameAsyncValidator(this.categoryService)]]
    })
  }

  onCancelClick(): void {
    this.dialogRef.close({valid: false});
  }

  editCategory(): void {
    this.categoryService.edit({id: this.data.id, name: this.categoryForm.get('name')?.value})
    .subscribe(
      res => {
        this.openSnackBar('Category edited');
        this.dialogRef.close();
      }
    )
  }

  onSubmit(): void {
    this.dialogRef.close({name: this.categoryForm.controls['name'].value, valid: this.categoryForm.valid});
  }

  private openSnackBar(message: string, time: number = 5000) {
    this.snackBar.open(message, 'Done', {
      duration: time,
    });
  }
}
