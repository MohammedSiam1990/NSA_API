import { Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { process } from '@progress/kendo-data-query';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { BrandService } from '../../services/brand.service';

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css'] ,
  providers: [MessageService],
})
export class BrandListComponent implements OnInit {

  public gridData: any[] = [];
  public gridViewArr: any[] = [];
  public pageSizes: any[] = [25, 50, 100, {
    text: this.translate.instant("All"),
    value: 'all'
  }];
  public pageSize = 25;
  private rtl = false;

  constructor(private brandService: BrandService, private loadingService: LoadingService,
    private messages: MessageService,
    public translate: TranslateService) {
    this.allData = this.allData.bind(this);
  }

  public ngOnInit(): void {
    this.changeDir();
    this.getBrands();
  }

  public changeDir() {
    if (this.translate.currentLang == "ar")
      this.rtl = true;
    else
      this.rtl = false;
    this.messages.notify(this.rtl);
  }

  WorkStations: any;
  getBrands(): void {
    this.brandService.getBrands(this.translate.currentLang).subscribe(res => {
      this.gridData = res.datalist;
      this.gridViewArr =this.gridData;
    })
  }

  showActive: boolean = false;
  title: string = "";
  getBrandsPending() {
    this.title = this.translate.instant("pending");
    this.showActive = false;
    var gridDataPending = this.gridData.filter(data => data.StatusID == 6);
    this.gridViewArr = gridDataPending;
    this.onFilter(this.keysearch);
  }

  getBrandsActive() {
    this.title = this.translate.instant("active");
    this.showActive = true;
    var gridDataActive = this.gridData.filter(data => data.StatusID == 7);
    this.gridViewArr = gridDataActive;
    this.onFilter(this.keysearch);
  }

  public onFilter(inputValue: string): void {
    this.gridViewArr = process(this.gridViewArr, {
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

  keysearch: string = "";
  search(inputValue: string) {
    this.keysearch = inputValue;
    if (!this.showActive)
      this.getBrandsPending();
    else
      this.getBrandsActive();
  }

  public allData(): ExcelExportData {
    const result: ExcelExportData = {
      data: process(this.gridViewArr, { sort: [{ field: 'CreateDateS', dir: 'asc' }] }).data,
    };
    return result;
  }
}
