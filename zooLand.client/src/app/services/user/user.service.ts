import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable()
export class UserService {

  constructor() { }

  getUsers() {
    return fetch(environment.apiHost + 'users', {
      method: 'get'
    }).then(res => res.json());
  }

  createUser(user) {
    return fetch(environment.apiHost + 'users', {
      method: 'post',
      body: JSON.stringify(user)
    }).then(createdUser => createdUser.json());
  }
}
