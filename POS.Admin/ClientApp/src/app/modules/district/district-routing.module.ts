import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddDistrictComponent } from './components/add-district/add-district.component';
import { DistrictListComponent } from './components/district-list/district-list.component';
import { UpdateDistrictComponent } from './components/update-district/update-district.component';


const routes: Routes = [{ path: "list", component: DistrictListComponent },
{ path: "add", component: AddDistrictComponent },
{ path: "edit/:id", component: UpdateDistrictComponent }];



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DistrictRoutingModule { }
