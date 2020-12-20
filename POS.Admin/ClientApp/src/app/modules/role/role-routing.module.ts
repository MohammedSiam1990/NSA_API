import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddRoleComponent } from './components/add-role/add-role.component';
import { RoleListComponent } from './components/role-list/role-list.component';

const routes: Routes = [
  { path: 'list', component: RoleListComponent, data: { breadcrumb: "user" } }
 , { path: 'add', component: AddRoleComponent, data: { breadcrumb: "Role" } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoleRoutingModule { }
