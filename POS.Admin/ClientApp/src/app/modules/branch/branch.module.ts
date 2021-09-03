import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchRoutingModule } from './branch-routing.module';
import { BranchListComponent } from './components/branch-list/branch-list.component';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { ActiveBranchComponent } from './components/active-branch/active-branch.component';
import { DeleteBranchComponent } from './components/delete-branch/delete-branch.component';


@NgModule({
  declarations: [BranchListComponent, ActiveBranchComponent, DeleteBranchComponent],
  imports: [
    CommonModule,
    BranchRoutingModule,
    SharedModule
  ]
})
export class BranchModule { }
