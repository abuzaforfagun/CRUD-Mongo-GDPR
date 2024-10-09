import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserState } from '../ngrx/user.reducer';
import { selectAllUsers } from '../ngrx/user.selectors';
import * as UserActions from '../ngrx/user.actions';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.scss'],
})
export class UserTableComponent implements OnInit {
  users$: Observable<any[]>;

  constructor(private store: Store<UserState>) {
    this.users$ = this.store.select(selectAllUsers);
  }

  ngOnInit(): void {
    this.store.dispatch(UserActions.loadUsers());
  }
}
