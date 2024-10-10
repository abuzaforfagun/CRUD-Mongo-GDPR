import { createSelector } from '@ngrx/store';
import { ProductState } from './product.reducer';

export const selectProductState = (state: any) => state.product;

export const selectLoading = createSelector(
  selectProductState,
  (state: ProductState) => state.loading
);

export const selectProducts = createSelector(
  selectProductState,
  (state: ProductState) => state.products
);

export const selectError = createSelector(
  selectProductState,
  (state: ProductState) => state.error
);
