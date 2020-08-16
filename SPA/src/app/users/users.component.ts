import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { AuthService } from '../../_services/auth.service';
import { AlertifyService } from '../../_services/alertify.service';
import { UserService } from 'src/_services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  users: User[];

  constructor(private userService: UserService, private alertify: AlertifyService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.loadUsers();
  }

  // tslint:disable-next-line: typedef
  loadUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
    }, error => {
      this.alertify.error(error);
    });
  }

}
