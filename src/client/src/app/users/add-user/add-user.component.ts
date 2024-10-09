import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { selectUserCreated } from '../ngrx/user.selectors';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as UserActions from '../ngrx/user.actions';
import { UserState } from '../ngrx/user.reducer';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss'],
})
export class AddUserComponent implements OnInit {
  userCreated$: Observable<boolean> = of(false);
  userForm: FormGroup;

  constructor(private store: Store<UserState>, private fb: FormBuilder) {
    console.log(store);
    this.userCreated$ = store.select(selectUserCreated);

    this.userForm = this.fb.group({
      fullName: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phone: ['', [Validators.required]],
      cprNumber: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.userCreated$ = this.store.select(selectUserCreated);
  }

  handleCreateUserSubmit() {
    if (this.userForm.valid) {
      this.store.dispatch(
        UserActions.submitUserForm({ userData: this.userForm.value })
      );
    } else {
      console.log('Form is invalid');
    }
  }
}
