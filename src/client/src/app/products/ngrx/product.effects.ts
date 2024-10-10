import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { HttpClient } from '@angular/common/http';
import { catchError, map, mergeMap, of } from 'rxjs';
import * as ProductActions from './product.actions';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProductEffects {
  loadProducts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ProductActions.loadProducts),
      mergeMap(() =>
        this.http.get<any[]>(`${environment.productsApi}/api/products`).pipe(
          map((response) =>
            ProductActions.loadProductsSuccess({ products: response })
          ),
          catchError((error) =>
            of(ProductActions.loadProductsFailure({ error: error.message }))
          )
        )
      )
    )
  );

  constructor(private actions$: Actions, private http: HttpClient) {}
}
