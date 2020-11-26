import { Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { process } from '@progress/kendo-data-query';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { DistrictService } from '../../services/district.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-district-list',
  templateUrl: './district-list.component.html',
  styleUrls: ['./district-list.component.css']
})
export class DistrictListComponent implements OnInit {

  public gridData: any[] = [];
  public gridViewArr: any[] = [];
  public pageSizes: any[] = [25, 50, 100, {
    text: this.translate.instant("All"),
    value: 'all'
  }];
  public pageSize = 25;
  private rtl = false;

  constructor(private districtService: DistrictService, private loadingService: LoadingService,
    private messages: MessageService,

    public translate: TranslateService) {
    this.allData = this.allData.bind(this);
  }

  public ngOnInit(): void {
    this.changeDir();
    this.getDistricts();
  }

  public changeDir() {
    if (this.translate.currentLang == "ar")
      this.rtl = true;
    else
      this.rtl = false;
    this.messages.notify(this.rtl);
  }

  WorkStations: any;
  getDistricts(): void {
    this.districtService.getDistricts(this.translate.currentLang).subscribe(res => {
      this.gridData = res.datalist;
      this.gridViewArr = this.gridData;

    })
  }

  public onFilter(inputValue: string): void {
    this.gridViewArr = process(this.gridData, {
      filter: {
        logic: "or",
        filters: [
          {
            field: "districtName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "districtNameAr",
            operator: "contains",
            value: inputValue
          },
          {
            field: "cityName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "cityNameAr",
            operator: "contains",
            value: inputValue
          }
          // ,
          // {
          //   field: "inActive",
          //   operator: "contains",
          //   value: inputValue,


          // }
        ]
      }
    }).data;
  }

  public allData(): ExcelExportData {
    const result: ExcelExportData = {
      data: process(this.gridViewArr, { sort: [{ field: 'districtName', dir: 'asc' }] }).data,
    };
    return result;
  }



}
