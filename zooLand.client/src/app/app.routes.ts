import {Routes} from '@angular/router';
import {AnimalsListComponent} from './animals-list/animals-list.component';
import {UsersComponent} from './users/users.component';

export const ROUTES: Routes = [
  {path: 'animals', component: AnimalsListComponent},
  {path: 'users', component: UsersComponent},
  {path: '**', redirectTo: 'animals'}
];


