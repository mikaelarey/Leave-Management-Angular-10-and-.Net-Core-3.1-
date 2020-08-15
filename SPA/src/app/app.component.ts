import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SPA';
  isLoggedIn = false;

  UserLogin(loggedIn: boolean): void {
    this.isLoggedIn = loggedIn;
  }

}
