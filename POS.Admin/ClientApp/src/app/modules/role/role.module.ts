import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleRoutingModule } from './role-routing.module';
import { AddRoleComponent } from './components/add-role/add-role.component';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { RoleListComponent } from './components/role-list/role-list.component';
import { EditRoleComponent } from './components/edit-role/edit-role.component';


@NgModule({
  declarations: [AddRoleComponent, RoleListComponent, EditRoleComponent],
  imports: [
    CommonModule,
    RoleRoutingModule,
    SharedModule
  ]
})
export class RoleModule { }
