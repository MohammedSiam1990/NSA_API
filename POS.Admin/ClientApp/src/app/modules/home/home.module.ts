import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SharedModule } from 'src/app/_shared/_shared.module';


@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    HomeRoutingModule
    , SharedModule
  ],
})
export class HomeModule { }
