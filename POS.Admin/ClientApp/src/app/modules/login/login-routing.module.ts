import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';


const routes: Routes = [
  { path: '', component: LoginComponent ,data: { breadcrumb: "login" }},
  { path: 'change-password', component: ForgetPasswordComponent ,data: { breadcrumb: "login" }},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
