import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrandRoutingModule } from './brand-routing.module';
import { BrandListComponent } from './components/brand-list/brand-list.component';
import { SharedModule } from 'src/app/_shared/_shared.module';


@NgModule({
  declarations: [BrandListComponent],
  imports: [
    CommonModule,
    BrandRoutingModule,
    SharedModule
  ]
})
export class BrandModule { }
