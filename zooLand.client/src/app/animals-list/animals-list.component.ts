import { Component, OnInit } from '@angular/core';
import {Animal} from '../models/Animal';
import {AnimalService} from '../services/animal/animal.service';

@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.css']
})
export class AnimalsListComponent implements OnInit {
  public animals: Animal[];

  constructor(private animalService: AnimalService) { }

  ngOnInit() {
    this.animalService.getAnimals()
      .then(animals => this.animals = animals);
  }

}
