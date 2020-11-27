import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { JwtService } from '../services/jwt.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  isLoginHit: boolean = false;
  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private jwtService: JwtService,
    private router: Router) {
    this.loginForm = this.fb.group({
      'username': ['', [Validators.required]],
      'password': ['', [Validators.required]]
    })
   }

  ngOnInit(): void {
  }

  login(): void{
    this.userService.login(this.loginForm.value).subscribe(data => {
      console.log(this.jwtService.decodeToken(data.token));
      this.userService.setUserData(data);
      this.router.navigateByUrl('/');
    });
  }
}
