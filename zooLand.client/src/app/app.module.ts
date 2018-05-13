import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgSelectComponent, NgSelectModule} from '@ng-select/ng-select';

import { AppComponent } from './app.component';
import { AnimalsListComponent } from './animals-list/animals-list.component';
import { AnimalComponent } from './animals-list/animal/animal.component';
import {UserService} from './services/user/user.service';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { UsersComponent } from './users/users.component';
import { UserComponent } from './users/user/user.component';
import { CreateUserComponent } from './users/create-user/create-user.component';
import {FormsModule} from '@angular/forms';
import { AnimalsComponent } from './animals/animals.component';
import {AnimalService} from './services/animal/animal.service';


@NgModule({
  declarations: [
    AppComponent,
    AnimalsListComponent,
    AnimalComponent,
    UsersComponent,
    UserComponent,
    CreateUserComponent,
    AnimalsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgSelectModule
  ],
  providers: [
    HttpClient,
    UserService,
    AnimalService,
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
