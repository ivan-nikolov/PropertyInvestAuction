import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router) {
    this.registerForm = this.fb.group({
      "username": ['', [Validators.required]],
      'email': ['', [Validators.required, Validators.email]],
      'password': ['', [Validators.required]],
      'confirmPassword': ['', [Validators.required]],
      
    }, { validator: this.ConfirmPasswordValidator("password", "confirmPassword") })
   }

  get email () {
    return this.registerForm.controls.email;
  }

  get useranme () {
    return this.registerForm.controls.username;
  }

  get confirmPassword () {
    return this.registerForm.controls.confirmPassword;
  }

  ngOnInit(): void {
  }

  register(){
    this.userService.register(this.registerForm.value).subscribe(data => {
      this.router.navigateByUrl('/login');
    })
  }

  ConfirmPasswordValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      let control = formGroup.controls[controlName];
      let matchingControl = formGroup.controls[matchingControlName]
      if (
        matchingControl.errors &&
        !matchingControl.errors.confirmPasswordValidator
      ) {
        return;
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmPasswordValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }
}
