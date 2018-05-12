import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';

@Injectable()
export class UserService {

  constructor(private http: HttpClient) { }

  getUsers() {
    return fetch(environment.apiHost + 'users', {
      method: 'get'
    });
  }

  createUser(user) {
    return fetch(environment.apiHost + 'users', {
      method: 'post',
      body: JSON.stringify(user)
    });
  }
}
