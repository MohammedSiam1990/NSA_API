import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MajorServiceRoutingModule } from './major-service-routing.module';
import { MajorServiceListComponent } from './components/major-service-list/major-service-list.component';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { AddMajorServiceComponent } from './components/add-major-service/add-major-service.component';
import { MajorServiceTypeListComponent } from './components/major-service-type-list/major-service-type-list.component';
import { DeleteServiceTypeComponent } from './components/delete-service-type/delete-service-type.component';


@NgModule({
  declarations: [MajorServiceListComponent, AddMajorServiceComponent, MajorServiceTypeListComponent, DeleteServiceTypeComponent],
  imports: [
    CommonModule,
    MajorServiceRoutingModule,
    SharedModule
  ]
})
export class MajorServiceModule { }
