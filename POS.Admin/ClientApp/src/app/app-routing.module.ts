import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './_shared/services/auth/auth.guard';


const routes: Routes = [
  { path: 'login', loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule) },
  {
    path: 'home', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule)
  },
  {
    path: 'user', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/user/user.module').then(m => m.UserModule)
  },
  {
    path: 'work-station', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/work-stations/work-stations.module').then(m => m.WorkStationsModule)
  },
  {
    path: 'company', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/company/company.module').then(m => m.CompanyModule)
  },
  { path: '', canActivateChild: [AuthGuard], redirectTo: 'home', pathMatch: 'full' },
  { path: '**', canActivateChild: [AuthGuard], redirectTo: 'home', pathMatch: 'full' },
  {
    path: '',
    redirectTo: "login",
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
