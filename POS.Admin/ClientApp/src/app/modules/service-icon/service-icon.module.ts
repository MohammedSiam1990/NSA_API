import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServiceIconRoutingModule } from './service-icon-routing.module';
import { AddServiceIconComponent } from './components/add-service-icon/add-service-icon.component';
import { ListServiceIconComponent } from './components/list-service-icon/list-service-icon.component';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { DeleteServiceIconComponent } from './components/delete-service-icon/delete-service-icon.component';


@NgModule({
  declarations: [AddServiceIconComponent, ListServiceIconComponent, DeleteServiceIconComponent],
  imports: [
    CommonModule,
    ServiceIconRoutingModule,
    SharedModule
  ]
})
export class ServiceIconModule { }
