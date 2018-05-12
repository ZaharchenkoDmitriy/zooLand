import { Component } from '@angular/core';
import {UserService} from './services/user/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private userService: UserService) {
    this.userService.createUser({Name: 'helloNigger'})
      .then(res => console.log(res));
    this.userService.createUser({Name: 'goodByNigger'})
      .then(res => console.log(res));

    this.userService.getUsers().then(res =>
        res.json())
        .then(users => {
      console.log(users);
    });
  }
}
