import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkStationsRoutingModule } from './work-stations-routing.module';
import { WorkStationsListComponent } from './components/work-stations-list/work-stations-list.component';
// import { ExcelModule, GridModule, PDFModule } from '@progress/kendo-angular-grid';
// import { InputsModule } from '@progress/kendo-angular-inputs';
import { SharedModule } from 'src/app/_shared/_shared.module';
import { DeleteWorkStationsComponent } from './components/delete-work-stations/delete-work-stations.component';
import { ActiveWorkStationsComponent } from './components/active-work-stations/active-work-stations.component';


@NgModule({
  declarations: [WorkStationsListComponent, DeleteWorkStationsComponent, ActiveWorkStationsComponent],
  imports: [
    CommonModule,
    // GridModule,
    WorkStationsRoutingModule,
    SharedModule
    // InputsModule,
    // PDFModule,
    // ExcelModule
  ]
})
export class WorkStationsModule { }
