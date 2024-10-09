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
