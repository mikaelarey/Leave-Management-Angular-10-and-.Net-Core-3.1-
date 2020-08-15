import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SPA';
  isLoggedIn: boolean;

  jwtHelper = new JwtHelperService();

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.loggedIn();
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }

  UserLogin(loggedIn: boolean): void {
    this.isLoggedIn = loggedIn;
  }

  loggedIn(): void {
    this.isLoggedIn = this.authService.loggedIn();
  }

}
