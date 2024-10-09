import { createReducer, on } from '@ngrx/store';
import * as UserActions from './user.actions';

export interface UserState {
  loading: boolean;
  userCreated: boolean;
  error: string | null;
  users: any[];
}

export const initialState: UserState = {
  loading: false,
  userCreated: false,
  error: null,
  users: [],
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
  }),
  on(UserActions.loadUsers, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(UserActions.loadUsersSuccess, (state, { users }) => ({
    ...state,
    loading: false,
    users,
  })),
  on(UserActions.loadUsersFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  }))
);
