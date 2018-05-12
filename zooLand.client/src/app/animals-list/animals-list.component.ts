import { Component, OnInit } from '@angular/core';
import {Animal} from '../models/Animal';
import {AnimalService} from '../services/animal/animal.service';

@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.css']
})
export class AnimalsListComponent implements OnInit {
  public animals: Animal[] = [];
  public splitedAnimals: {class: string, animals: Animal[]}[] = [];

  constructor(private animalService: AnimalService) { }

  ngOnInit() {
    this.animalService.getAnimals()
      .then(animals => {
        this.animals = animals;
        this.splitAnimalsByClass();
      });
  }

  splitAnimalsByClass() {
    while (this.animals[0]) {
      this.splitedAnimals.push({class: this.animals[0].AnimalClass, animals: []});
      this.splitedAnimals[this.splitedAnimals.length - 1].animals = this.animals
        .filter( animal => animal.AnimalClass === this.animals[0].AnimalClass);
      this.animals = this.animals.map(animal => {
          if (animal.AnimalClass !== this.animals[0].AnimalClass) {
            return animal;
          }
      });
    }
  }
}
