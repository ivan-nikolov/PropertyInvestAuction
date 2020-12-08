import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {

  categories: Category[];
  displayedColumns: string[] = ['id', 'name', 'actions'];

  constructor(
    private categoryService: CategoryService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.loadCategories();
  }

  create() : void {
    console.log('create');
  }

  edit(category: Category) {
    console.log(category);
  }

  delete(id: string) {
    this.categoryService.delete(id).subscribe(
      res => {
        this.loadCategories();
        this.openSnackBar('Category is Deleted.');
      },
      err => {
        this.openSnackBar(err.error.message, 0);
      }
    )
  }

  private loadCategories(){
    this.categoryService.loadCategories()
        .subscribe(
          res => {
            this.categories = res;
          }
        )
  }

  private openSnackBar(message: string, time: number = 5000) {
    this.snackBar.open(message, 'Done', {
      duration: time,
    });
  }
}
