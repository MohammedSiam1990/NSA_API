import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddCityComponent } from './components/add-city/add-city.component';
import { CitiesListComponent } from './components/cities-list/cities-list.component';
import { UpdateCityComponent } from './components/update-city/update-city.component';


const routes: Routes = [{ path: 'list', component: CitiesListComponent, data: { breadcrumb: "City" } },
{ path: 'add', component: AddCityComponent, data: { breadcrumb: "City" } },
{ path: "edit/:id", component: UpdateCityComponent , data: { breadcrumb: "City" }}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CityRoutingModule { }
