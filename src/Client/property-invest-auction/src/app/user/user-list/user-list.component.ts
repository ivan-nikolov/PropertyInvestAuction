import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { User } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements AfterViewInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;

  displayedColumns: string[] = ['id', 'username', 'email', 'roles', 'actions'];
  dataSource = new MatTableDataSource<User>();
  constructor(private userService: UserService) {
    
   }


  ngAfterViewInit(): void {
    this.userService.getCount().subscribe(count => {
      this.paginator.length = count;
    });

    this.loadUsers(0, 5);
    this.dataSource.paginator = this.paginator;
  }

   loadUsers(pageIndex: number, pageSize: number){
     console.log("load users");
    this.userService.all(pageIndex, pageSize).subscribe(data => {
      this.dataSource = new MatTableDataSource<User>(data);
    });
   }

   addToAdmin(userId: string) {
     console.log(userId);
     this.userService.addToAdmin(userId).subscribe(res => {
      this.loadUsers(this.paginator.pageIndex, this.paginator.pageSize);
     });
     
   }

   removeFromAdmin(userId: string){
    this.userService.removeFromAdmin(userId).subscribe(res => {
      this.loadUsers(this.paginator.pageIndex, this.paginator.pageSize);
    });
   }
}
