import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { HttpClient } from '@angular/common/http';
import { catchError, map, mergeMap, of } from 'rxjs';
import * as UserActions from './user.actions';

@Injectable()
export class UserEffects {
  submitUserForm$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UserActions.submitUserForm),
      mergeMap((action) =>
        this.http.post('http://localhost:5036/api/users', action.userData).pipe(
          map((response) => UserActions.submitUserFormSuccess({ response })),
          catchError((error) =>
            of(UserActions.submitUserFormFailure({ error }))
          )
        )
      )
    )
  );

  constructor(private actions$: Actions, private http: HttpClient) {}
}