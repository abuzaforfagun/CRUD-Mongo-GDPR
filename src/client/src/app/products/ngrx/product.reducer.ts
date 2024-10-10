import { createReducer, on } from '@ngrx/store';
import * as ProductActions from './product.actions';
import { stat } from 'fs';

export interface ProductState {
  loading: boolean;
  error: string | null;
  products: any[];
  categories: any[];
}

export const initialState: ProductState = {
  loading: false,
  error: null,
  products: [],
  categories: [
    { value: '67066849e37b300a1208d7aa', label: 'Books' },
    { value: '67066849e37b300a1208d7ac', label: 'Clothing' },
    { value: '67066849e37b300a1208d7ab', label: 'Electronics' },
    { value: '67066849e37b300a1208d7aa', label: 'Grocery' },
  ],
};

export const productReducer = createReducer(
  initialState,
  on(ProductActions.loadProducts, (state) => {
    return {
      ...state,
      loading: true,
      error: null,
    };
  }),
  on(ProductActions.loadProductsSuccess, (state, { products }) => {
    console.log('loadProductSuccess action received');
    return {
      ...state,
      loading: false,
      products: products,
    };
  }),
  on(ProductActions.loadProductsFailure, (state, { error }) => {
    console.log('loadProductFailure action received', error);
    return {
      ...state,
      loading: false,
      error: error,
    };
  })
);
