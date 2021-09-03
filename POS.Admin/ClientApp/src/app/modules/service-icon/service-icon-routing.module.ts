import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddServiceIconComponent } from './components/add-service-icon/add-service-icon.component';
import { ListServiceIconComponent } from './components/list-service-icon/list-service-icon.component';


const routes: Routes = [{ path: 'list', component: ListServiceIconComponent, data: { breadcrumb: "serviceIcon" } }
                         , { path: 'add', component: AddServiceIconComponent, data: { breadcrumb: "serviceIcon" } },];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServiceIconRoutingModule { }
