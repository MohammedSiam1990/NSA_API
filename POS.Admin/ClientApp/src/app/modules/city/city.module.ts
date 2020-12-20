import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CityRoutingModule } from './city-routing.module';
import { CitiesListComponent } from './components/cities-list/cities-list.component';
import { AddCityComponent } from './components/add-city/add-city.component';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { UpdateCityComponent } from './components/update-city/update-city.component';


@NgModule({
  declarations: [CitiesListComponent, AddCityComponent, UpdateCityComponent],
  imports: [
    CommonModule,
    CityRoutingModule,
    SharedModule
  ]
})
export class CityModule { }
