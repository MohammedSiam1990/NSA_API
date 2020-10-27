import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { SharedModule } from 'src/app/_shared/_shared.module';


@NgModule({
  declarations: [ChangePasswordComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    SharedModule

  ]
})
export class UserModule { }
