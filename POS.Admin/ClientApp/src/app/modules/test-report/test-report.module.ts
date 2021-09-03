import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestReportRoutingModule } from './test-report-routing.module';
import { ReportComponent } from './report/report.component';
import { TelerikReportingModule } from '@progress/telerik-angular-report-viewer';
import { SharedModule } from '@progress/kendo-angular-grid';


@NgModule({
  declarations: [ReportComponent],
  imports: [
    CommonModule,
    TestReportRoutingModule,
    // SharedModule,
    TelerikReportingModule
  ]
})
export class TestReportModule { }
