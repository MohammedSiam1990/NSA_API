import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { companyModel } from '../../models/company';
import { CompanyService } from '../../services/company.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import {process } from '@progress/kendo-data-query';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css'],
  providers: [MessageService],
})
export class CompanyListComponent implements OnInit {

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

  constructor(private companyService: CompanyService, private loadingService: LoadingService,
    private messages: MessageService,
    public translate: TranslateService) {
      this.allData = this.allData.bind(this);
  }

  public ngOnInit(): void {
    this.changeDir();
    this.getCompanies();

  }


  public changeDir() {
    if (this.translate.currentLang == "ar")
      this.rtl = true;
    else
      this.rtl = false;
    this.messages.notify(this.rtl);
  }

  WorkStations: any;
  getCompanies(): void {
    this.companyService.getCompanies(this.translate.currentLang).subscribe(res => {
      debugger
      this.gridData = res.datalist;
      this.gridViewArr = this.gridData;
    })

  }

  activeWorkStations(model: companyModel) {
    // this.activeWorkStationsCom.show(model);

  }

  deleteWorkStations(model: companyModel) {
    // this.deleteWorkStationsCom.show(model);
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
            field: "CompanyNameAr",
            operator: "contains",
            value: inputValue
          },
          {
            field: "CompanyEmail",
            operator: "contains",
            value: inputValue
          },
          {
            field: "Phone",
            operator: "contains",
            value: inputValue
          },
          {
            field: "CountryName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "CountryNameAr",
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
