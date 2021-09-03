import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMajorServiceComponent } from './components/add-major-service/add-major-service.component';
import { MajorServiceListComponent } from './components/major-service-list/major-service-list.component';
import { MajorServiceTypeListComponent } from './components/major-service-type-list/major-service-type-list.component';


const routes: Routes = [{ path: "list", component: MajorServiceListComponent },
{ path: "add", component: AddMajorServiceComponent },
{ path: "service-type", component: MajorServiceTypeListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MajorServiceRoutingModule { }
