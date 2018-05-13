import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import {User} from '../../models/User';
import {Animal} from '../../models/Animal';

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

  setUserOnAnimal(user: User, animal: Animal) {
    return fetch(environment.apiHost + 'users/animal?userId=' + user.ID, {
      method: 'post',
      body: JSON.stringify(animal)
    }).then(res => res.json());
  }
}
