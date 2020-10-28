import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkStationsListComponent } from './components/work-stations-list/work-stations-list.component';


const routes: Routes = [{ path: 'list', component: WorkStationsListComponent ,data: { breadcrumb: "WorkStations" }},];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkStationsRoutingModule { }
