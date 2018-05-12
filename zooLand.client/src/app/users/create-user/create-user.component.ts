import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {User} from '../../models/User';
import {UserService} from '../../services/user/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  public user: User;

  constructor(private userService: UserService) { }

  @Output() userCreated: EventEmitter<User> = new EventEmitter<User>();
  ngOnInit() {
    this.user = new User();
  }

  createUser(event) {
    event.preventDefault();

    this.userService.createUser(this.user)
      .then(user => {
        this.userCreated.emit(user);
      });
  }
}
