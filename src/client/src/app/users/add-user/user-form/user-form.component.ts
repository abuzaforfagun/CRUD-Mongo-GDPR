import { Component, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import * as UserActions from '../../ngrx/user.actions';
import { UserState } from '../../ngrx/user.reducer';
import { Observable, of } from 'rxjs';
import { selectUserCreated } from '../../ngrx/user.selectors';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent implements OnInit {
  @Input() onSubmit!: () => void;
  @Input() userForm!: FormGroup;
  constructor() {}
  ngOnInit(): void {}
}
