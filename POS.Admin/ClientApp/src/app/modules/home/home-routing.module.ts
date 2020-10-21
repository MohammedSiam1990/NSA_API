import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';


const routes: Routes = [
  { path: '', component: DashboardComponent ,data: { breadcrumb: "home" }},
];

@NgModule({
  imports: [RouterModule.forChild(routes)
    , SharedModule],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
