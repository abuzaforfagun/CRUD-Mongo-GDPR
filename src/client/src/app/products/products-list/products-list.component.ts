import { Component, OnInit } from '@angular/core';
import { ProductState } from '../ngrx/product.reducer';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { selectProducts } from '../ngrx/product.selectors';
import * as ProductActions from '../ngrx/product.actions';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss'],
})
export class ProductsListComponent implements OnInit {
  products$: Observable<any[]>;
  constructor(private store: Store<ProductState>) {
    this.products$ = this.store.select(selectProducts);
  }

  ngOnInit(): void {
    this.store.dispatch(ProductActions.loadProducts());
    this.products$.subscribe((p) => {
      console.log(p);
    });
  }
}
