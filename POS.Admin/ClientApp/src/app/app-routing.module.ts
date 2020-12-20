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
  {
    path: 'branch', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/branch/branch.module').then(m => m.BranchModule)
  },
  {
    path: 'brand', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/brand/brand.module').then(m => m.BrandModule)
  },
  {
    path: 'service-icon', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/service-icon/service-icon.module').then(m => m.ServiceIconModule)
  },
  {
    path: 'major-service-type', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/major-service/major-service.module').then(m => m.MajorServiceModule)
  },
  {
    path: 'district', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/district/district.module').then(m => m.DistrictModule)
  },
  {
    path: 'city', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/city/city.module').then(m => m.CityModule)
  },
  {
    path: 'report', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/test-report/test-report.module').then(m => m.TestReportModule)
  },
  {
    path: 'user', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/user/user.module').then(m => m.UserModule)
  },
  {
    path: 'role', canActivateChild: [AuthGuard],
    loadChildren: () => import('./modules/role/role.module').then(m => m.RoleModule)
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
