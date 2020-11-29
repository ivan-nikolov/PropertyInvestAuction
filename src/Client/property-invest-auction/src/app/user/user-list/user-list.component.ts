import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { fromEvent } from 'rxjs';
import { debounceTime, distinctUntilChanged, tap } from 'rxjs/operators'
import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements AfterViewInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('input') input: ElementRef;

  displayedColumns: string[] = ['id', 'username', 'email', 'roles', 'actions'];
  dataSource = new MatTableDataSource<User>();
  constructor(private userService: UserService) {
    
   }


  ngAfterViewInit(): void {
    this.userService.getCount().subscribe(count => {
      this.paginator.length = count;
    });

    fromEvent(this.input.nativeElement,'keyup')
            .pipe(
                debounceTime(200),
                distinctUntilChanged(),
                tap(() => {
                    this.paginator.pageIndex = 0;
                })
            )
            .subscribe(res => {
              this.loadUsers(this.paginator.pageIndex, this.paginator.pageSize, this.input.nativeElement.value);
            });

    this.loadUsers(0, 5, '');
    this.dataSource.paginator = this.paginator;
  }

   loadUsers(pageIndex: number, pageSize: number, query: string){
    this.userService.all(pageIndex, pageSize, query).subscribe(data => {
      this.dataSource = new MatTableDataSource<User>(data);
      console.log(data);
    });
   }

   addToAdmin(userId: string) {
     console.log(userId);
     this.userService.addToAdmin(userId).subscribe(res => {
      this.loadUsers(this.paginator.pageIndex, this.paginator.pageSize, this.input.nativeElement.value);
     });
     
   }

   removeFromAdmin(userId: string){
    this.userService.removeFromAdmin(userId).subscribe(res => {
      this.loadUsers(this.paginator.pageIndex, this.paginator.pageSize, this.input.nativeElement.value);
    });
   }
}
