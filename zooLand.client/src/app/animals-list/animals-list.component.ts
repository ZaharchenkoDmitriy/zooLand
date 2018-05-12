import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.css']
})
export class AnimalsListComponent implements OnInit {
  public animals: {name: string, foodType: string}[] = [];

  constructor() { }

  ngOnInit() {
    this.animals.push({name: 'LionMisha', foodType: 'Meat'});
  }

}
