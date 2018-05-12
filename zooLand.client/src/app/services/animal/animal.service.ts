import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';

@Injectable()
export class AnimalService {
  private url = environment.apiHost + 'animals/';

  constructor() { }

  getAnimals() {
    return fetch(this.url, {
      method: 'get'
    }).then(animals => animals.json());
  }
}
