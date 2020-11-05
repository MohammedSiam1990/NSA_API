import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchRoutingModule } from './branch-routing.module';
import { BranchListComponent } from './components/branch-list/branch-list.component';
import { SharedModule } from 'src/app/_shared/_shared.module';


@NgModule({
  declarations: [BranchListComponent],
  imports: [
    CommonModule,
    BranchRoutingModule,
    SharedModule
  ]
})
export class BranchModule { }
