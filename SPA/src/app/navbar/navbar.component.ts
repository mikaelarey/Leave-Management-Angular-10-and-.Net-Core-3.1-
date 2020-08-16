import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AlertifyService } from 'src/_services/alertify.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Output() logoutButtonClick = new EventEmitter();

  constructor(private alertify: AlertifyService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
  }

  logout(): void {
    localStorage.removeItem('token');
    this.alertify.message('Successfully logged out.');
    this.logoutButtonClick.emit(false); // Set the isLoggedin to false
  }
}
