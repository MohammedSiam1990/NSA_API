import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ConfirmEmailComponent } from './components/confirm-email/confirm-email.component';
import { ResentEmailComponent } from './components/resent-email/resent-email.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';


const routes: Routes = [
  { path: '', component: LoginComponent, data: { breadcrumb: "login" } },
  // { path: 'change-password', component: ForgetPasswordComponent, data: { breadcrumb: "login" } },
  { path: 'confirm-email', component: ConfirmEmailComponent, data: { breadcrumb: "email" } },
  { path: 'resend-email', component: ResentEmailComponent, data: { breadcrumb: "resend" } },
{ path: 'change-password', component: ChangePasswordComponent ,data: { breadcrumb: "user" }}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
