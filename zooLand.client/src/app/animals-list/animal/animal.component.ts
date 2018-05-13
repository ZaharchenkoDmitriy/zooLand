import {Component, Input, OnInit} from '@angular/core';
import {Animal} from '../../models/Animal';
import {UserService} from '../../services/user/user.service';
import {User} from '../../models/User';
import {AnimalService} from '../../services/animal/animal.service';

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.css']
})
export class AnimalComponent implements OnInit {

  constructor(private userService: UserService, private animalService: AnimalService) { }

  @Input() animal: Animal;

  public users: User[];
  public selectedUser: User;

  ngOnInit() {
    this.userService.getUsers()
      .then(users => this.users = users);
    this.animalService.getAppointedUser(this.animal)
      .then(user => this.selectedUser = user);
  }

  save() {
    this.userService.setUserOnAnimal(this.selectedUser, this.animal)
      .then(res => {
      });
  }
}
