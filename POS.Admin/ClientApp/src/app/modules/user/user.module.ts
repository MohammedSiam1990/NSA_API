import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { ChangePasswordComponent } from './components/change-password/change-password.component';


@NgModule({
  declarations: [ChangePasswordComponent],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
