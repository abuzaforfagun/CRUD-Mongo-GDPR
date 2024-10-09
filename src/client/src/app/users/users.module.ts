import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list/user-list.component';
import { AddUserComponent } from './add-user/add-user.component';
import { UserFormComponent } from './add-user/user-form/user-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { userReducer } from './ngrx/user.reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserEffects } from './ngrx/user.effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { UserTableComponent } from './user-table/user-table.component';

@NgModule({
  declarations: [UserListComponent, AddUserComponent, UserFormComponent, UserTableComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    StoreDevtoolsModule.instrument({ maxAge: 25 }),
  ],
})
export class UsersModule {}
