import {Component, Input, OnInit} from '@angular/core';
import {Animal} from '../../models/Animal';

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.css']
})
export class AnimalComponent implements OnInit {

  constructor() { }

  @Input() animal: Animal;

  ngOnInit() {
  }

}
