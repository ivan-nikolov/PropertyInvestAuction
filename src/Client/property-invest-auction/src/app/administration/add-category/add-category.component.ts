import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  categoryForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<AddCategoryComponent>,
    private fb: FormBuilder,
    private categoryService: CategoryService,
    private snackBar: MatSnackBar
    ) { }

  ngOnInit(): void {
    this.createCategoryForm();
  }

  addCategory(): void {
    this.categoryService.create(this.categoryForm.value).subscribe(
      res => {
        this.openSnackBar('Category Created');
        this.dialogRef.close();
      },
      err => {
        this.openSnackBar(err.error);
      }
    )
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  private createCategoryForm() {
    this.categoryForm = this.fb.group({
      'name': ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]]
    })
  }

  private openSnackBar(message: string, time: number = 5000) {
    this.snackBar.open(message, 'Done', {
      duration: time,
    });
  }
}
