import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AlertifyService } from 'src/_services/alertify.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from 'src/_services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  user: any;
  @Output() logoutButtonClick = new EventEmitter();

  constructor(private alertify: AlertifyService, private authService: AuthService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.user = this.authService.decodedToken;
  }

  logout(): void {
    localStorage.removeItem('token');
    this.alertify.message('Successfully logged out.');
    this.logoutButtonClick.emit(false); // Set the isLoggedin to false
  }
}
