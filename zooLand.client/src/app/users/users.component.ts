import { Component, OnInit } from '@angular/core';
import {UserService} from '../services/user/user.service';
import {User} from '../models/User';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public users: User[];
  public creatingUser = false;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUsers().then(users => this.users = users);
  }

  userCreated(user) {
    this.users.push(user);
    this.creatingUser = false;
  }
}
