import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BranchListComponent } from './components/branch-list/branch-list.component';


const routes: Routes = [{path:"list",component:BranchListComponent,data: { breadcrumb: "branch" }}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchRoutingModule { }
