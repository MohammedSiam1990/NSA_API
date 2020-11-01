import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { SharedModule } from 'src/app/_shared/_shared.module';


@NgModule({
  declarations: [CompanyListComponent],
  imports: [
    CommonModule,
    CompanyRoutingModule,
    SharedModule
  ]
})
export class CompanyModule { }
