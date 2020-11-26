import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DistrictRoutingModule } from './district-routing.module';
import { DistrictListComponent } from './components/district-list/district-list.component';
import { AddDistrictComponent } from './components/add-district/add-district.component';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { UpdateDistrictComponent } from './components/update-district/update-district.component';


@NgModule({
  declarations: [DistrictListComponent, AddDistrictComponent, UpdateDistrictComponent],
  imports: [
    CommonModule,
    DistrictRoutingModule,
    SharedModule
  ]
})
export class DistrictModule { }
