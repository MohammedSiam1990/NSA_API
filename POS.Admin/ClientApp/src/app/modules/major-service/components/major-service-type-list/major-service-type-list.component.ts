import { Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PageSizeItem } from '@progress/kendo-angular-grid';
import { MessageService } from '@progress/kendo-angular-l10n';
import { GroupDescriptor, DataResult, process, SortDescriptor } from '@progress/kendo-data-query';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { MajorServiceService } from '../../services/major-service.service';
import { MajorServicesModel } from 'src/app/modules/service-icon/models/service-icons-model';
@Component({
  selector: 'app-major-service-type-list',
  templateUrl: './major-service-type-list.component.html',
  styleUrls: ['./major-service-type-list.component.css']
})
export class MajorServiceTypeListComponent implements OnInit {

  public gridData: any[] = [];
  public gridViewArr: any[] = [];
  public pageSizes: any[] = [25, 50, 100, {
    text: this.translate.instant("All"),
    value: 'all'
  }];
  public pageSize = 25;
  private rtl = false;
  // @ViewChild("deleteWorkStationsCom") deleteWorkStationsCom: DeleteWorkStationsComponent;
  // @ViewChild("activeWorkStationsCom") activeWorkStationsCom: ActiveWorkStationsComponent;

  constructor(private majorServiceService: MajorServiceService, private loadingService: LoadingService,
    private messages: MessageService,
    public translate: TranslateService) {
    this.allData = this.allData.bind(this);
  }

  public ngOnInit(): void {
    this.changeDir();
    this.getMajorServices();

  }


  public changeDir() {
    if (this.translate.currentLang == "ar")
      this.rtl = true;
    else
      this.rtl = false;
    this.messages.notify(this.rtl);
  }

  getServiceTypesByMajorServiceId() {
    this.majorServiceService.getMajorServiceTypesByMajorServiceId(this.serviceId, this.translate.currentLang).subscribe(res => {
      this.gridData = res.datalist;
      this.gridData.forEach(element => {
        element.CreateDate = new Date(element.CreateDate);
      });
      this.gridViewArr = this.gridData;
    })
  }

  serviceId: number=1;
  majorServicesArr: any = [];
  getMajorServices() {
    this.majorServiceService.getMajorServices(this.translate.currentLang).subscribe(res => {
      this.majorServicesArr = res.datalist;
      this.getServiceTypesByMajorServiceId();
    })
  }

  onChangeMajorService($event) {
    this.getServiceTypesByMajorServiceId();
  }

  keysearch: string = "";
  public onFilter(inputValue: string): void {
    this.gridViewArr = process(this.gridData, {
      filter: {
        logic: "or",
        filters: [
          {
            field: "typeName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "typeNameAr",
            operator: "contains",
            value: inputValue
          },

        ]
      }
    }).data;
  }

  public allData(): ExcelExportData {
    const result: ExcelExportData = {
      data: process(this.gridViewArr, { sort: [{ field: 'typeName', dir: 'asc' }] }).data,
    };
    return result;
  }


}
