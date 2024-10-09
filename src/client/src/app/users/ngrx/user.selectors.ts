import { createSelector } from '@ngrx/store';
import { UserState } from './user.reducer';

export const selectUserState = (state: any) => state.user;

export const selectLoading = createSelector(
  selectUserState,
  (state: UserState) => state.loading
);

export const selectUserCreated = createSelector(
  selectUserState,
  (state: UserState) => state.userCreated
);

export const selectError = createSelector(
  selectUserState,
  (state: UserState) => state.error
);

export const selectAllUsers = createSelector(
  selectUserState,
  (state: UserState) => state.users
);
