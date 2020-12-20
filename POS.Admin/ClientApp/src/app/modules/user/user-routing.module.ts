import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddUserComponent } from './components/add-user/add-user.component';
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { ListUserComponent } from './components/list-user/list-user.component';


const routes: Routes = [{ path: 'list', component: ListUserComponent, data: { breadcrumb: "user" } }
  , { path: 'add', component: AddUserComponent, data: { breadcrumb: "user" } },
  { path: "edit/:id", component: EditUserComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
