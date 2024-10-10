import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductCardComponent } from './product-card/product-card.component';



@NgModule({
  declarations: [
    ProductsListComponent,
    ProductCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductsModule { }
