import { createReducer, on } from '@ngrx/store';
import * as UserActions from './user.actions';

export interface UserState {
  loading: boolean;
  userCreated: boolean;
  error: string | null;
}

export const initialState: UserState = {
  loading: false,
  userCreated: false,
  error: null,
};

export const userReducer = createReducer(
  initialState,
  on(UserActions.submitUserForm, (state) => {
    console.log('submitUserForm action received');
    return {
      ...state,
      loading: true,
      error: null,
    };
  }),
  on(UserActions.submitUserFormSuccess, (state) => {
    console.log('submitUserFormSuccess action received');
    return {
      ...state,
      userCreated: true,
      loading: false,
    };
  }),
  on(UserActions.submitUserFormFailure, (state, { error }) => {
    console.log('submitUserFormFailure action received', error);
    return {
      ...state,
      loading: false,
      error: error,
    };
  })
);
