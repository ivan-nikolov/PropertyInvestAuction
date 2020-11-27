import { Component, OnInit } from '@angular/core';
import { UserService } from '../../user/services/user.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent {

  get isAuthenticated () {
    return this.userService.isAuthenticated();
  }

  constructor(private userService: UserService) { }

  logout() {
    this.userService.logout();
  }
}
