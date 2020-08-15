import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from 'src/_services/alertify.service';
import { HttpClient } from '@angular/common/http';

import { AuthService } from '../../_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @Output() loginButtonClick = new EventEmitter();

  hasAdmin: any;
  registerMode = false;

  model: any = {};

  constructor(private alertify: AlertifyService, private http: HttpClient, private authService: AuthService) { }

  ngOnInit(): void {
    this.adminUserExists();
  }

  adminUserExists(): void {
    this.http.get('http://localhost:5000/auth/get-admin').subscribe(
      response => {
        this.hasAdmin = response;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  login(): void {
    this.loginButtonClick.emit(true);
    this.alertify.success('Logged in successful!');
  }

  register(): void {
    this.registerMode = true;
  }

  loginMode(): void {
    this.registerMode = false;
  }

  registerUser(): void {
    this.authService.register(this.model).subscribe(
      () => {
        this.alertify.success('Registration Successful!');
        this.registerMode = false;
      }, error => {
        this.alertify.error('Unable to register user');
      });
  }
}
