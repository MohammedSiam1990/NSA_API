import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './components/login/login.component';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { ConfirmEmailComponent } from './components/confirm-email/confirm-email.component';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { ResentEmailComponent } from './components/resent-email/resent-email.component';
import { ConfirmVerificationCodeComponent } from './components/confirm-verification-code/confirm-verification-code.component';


@NgModule({
  declarations: [LoginComponent, ConfirmEmailComponent, ForgetPasswordComponent, ResentEmailComponent, ConfirmVerificationCodeComponent],
  imports: [
    SharedModule,
    CommonModule,
    LoginRoutingModule
  ]
})
export class LoginModule { }
