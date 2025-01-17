import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersModule } from './users/users.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { UserEffects } from './users/ngrx/user.effects';
import { userReducer } from './users/ngrx/user.reducer';
import { ProductsModule } from './products/products.module';
import { productReducer } from './products/ngrx/product.reducer';
import { ProductEffects } from './products/ngrx/product.effects';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UsersModule,
    ProductsModule,
    StoreModule.forRoot({ user: userReducer, product: productReducer }),
    EffectsModule.forRoot([UserEffects, ProductEffects]),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
