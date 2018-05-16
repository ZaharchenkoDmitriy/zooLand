import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {Animal} from '../../models/Animal';

@Injectable()
export class AnimalService {
  private url = environment.apiHost + 'animals/';

  constructor() { }

  getAnimals() {
    return fetch(this.url, {
      method: 'get'
    }).then(animals => animals.json());
  }

  getAppointedUser(animal: Animal) {
    return fetch(this.url + 'appointed-user', {
      method: 'post',
      body: JSON.stringify(animal)
    })
      .then(res => res.json());
  }

  feed(animal: Animal) {
    return fetch(this.url + 'feed-today', {
      method: 'post',
      body: JSON.stringify(animal)
    }). then(res => res.json());
  }
}
