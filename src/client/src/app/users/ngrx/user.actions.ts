import { createAction, props } from '@ngrx/store';

export const submitUserForm = createAction(
  '[User] Submit User Form',
  props<{ userData: any }>()
);

export const submitUserFormSuccess = createAction(
  '[User] Submit User Form Success',
  props<{ response: any }>()
);

export const submitUserFormFailure = createAction(
  '[User] Submit User Form Failure',
  props<{ error: any }>()
);

export const loadUsers = createAction('[User] Load Users');

export const loadUsersSuccess = createAction(
  '[User] Load Users Success',
  props<{ users: any[] }>()
);

export const loadUsersFailure = createAction(
  '[User] Load Users Failure',
  props<{ error: string }>()
);
