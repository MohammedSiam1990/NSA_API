import { Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PageSizeItem } from '@progress/kendo-angular-grid';
import { MessageService } from '@progress/kendo-angular-l10n';
import { GroupDescriptor, DataResult, process, SortDescriptor } from '@progress/kendo-data-query';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { BranchWorkStationsModel } from '../../models/work-stations-model';
import { WorkStationService } from '../../services/work-station.service';
import { ActiveWorkStationsComponent } from '../active-work-stations/active-work-stations.component';
import { DeleteWorkStationsComponent } from '../delete-work-stations/delete-work-stations.component';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';


@Component({
  selector: 'app-work-stations-list',
  templateUrl: './work-stations-list.component.html',
  styleUrls: ['./work-stations-list.component.css'],
  providers: [MessageService],
})
export class WorkStationsListComponent implements OnInit {

  public gridData: any[] = [];
  public gridViewArr: any[] = [];
  public pageSizes: any[] = [25, 50, 100, {
    text: this.translate.instant("All"),
    value: 'all'
}];
  public pageSize = 25;
  private rtl = false;
  @ViewChild("deleteWorkStationsCom") deleteWorkStationsCom: DeleteWorkStationsComponent;
  @ViewChild("activeWorkStationsCom") activeWorkStationsCom: ActiveWorkStationsComponent;

  constructor(private workStationService: WorkStationService, private loadingService: LoadingService,
    private messages: MessageService,
    public translate: TranslateService) {
      this.allData = this.allData.bind(this);
  }

  public ngOnInit(): void {
    this.changeDir();
    this.getWorkStations();

  }


  public changeDir() {
    if (this.translate.currentLang == "ar")
      this.rtl = true;
    else
      this.rtl = false;
    this.messages.notify(this.rtl);
  }

  WorkStations: any;
  getWorkStations(): void {
    this.workStationService.getWorkStations(this.translate.currentLang).subscribe(res => {
      this.gridData = res.datalist;
      this.getWorkStationsPending();
    })

  }

  getWorkStationsPending() {
    var gridDataPending = this.gridData.filter(data => data.StatusID == 6);
    this.gridViewArr = gridDataPending;
  }

  getWorkStationsActive() {
    var gridDataActive = this.gridData.filter(data => data.StatusID == 7);
    this.gridViewArr = gridDataActive;
  }

  activeWorkStations(model: BranchWorkStationsModel) {
    this.activeWorkStationsCom.show(model);

  }

  deleteWorkStations(model: BranchWorkStationsModel) {
    this.deleteWorkStationsCom.show(model);
  }

  public onFilter(inputValue: string): void {
    this.gridViewArr = process(this.gridData, {
      filter: {
        logic: "or",
        filters: [
          {
            field: "CompanyName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "BrandName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "BranchName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "WorkstationName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "Phone",
            operator: "contains",
            value: inputValue
          },
          {
            field: "CreateDateS",
            operator: "contains",
            value: inputValue
          }
        ]
      }
    }).data;
  }

  public allData(): ExcelExportData {
    const result: ExcelExportData =  {
        data: process(this.gridViewArr, {  sort: [{ field: 'CreateDateS', dir: 'asc' }] }).data,
    };
    return result;
}

}
