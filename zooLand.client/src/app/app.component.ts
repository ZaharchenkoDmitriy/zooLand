import { Component } from '@angular/core';
import {UserService} from './services/user/user.service';
import {environment} from '../environments/environment';
import {Animal} from './models/Animal';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor() {
    fetch(environment.apiHost + 'users/animal?userId=1', {
      method: 'post',
      body: JSON.stringify({ID: 1, Name: 'Grisha'})
    }).then(res => res.json())
      .then(res => console.log(res));
  }
}
