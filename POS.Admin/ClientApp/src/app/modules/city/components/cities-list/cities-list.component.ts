import { Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { process } from '@progress/kendo-data-query';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { CityService } from '../../services/city.service';
import { CountryModel } from 'src/app/modules/district/models/country-model';
import { DistrictService } from 'src/app/modules/district/services/district.service';


@Component({
  selector: 'app-cities-list',
  templateUrl: './cities-list.component.html',
  styleUrls: ['./cities-list.component.css']
})
export class CitiesListComponent implements OnInit {

  public gridData: any[] = [];
  public gridViewArr: any[] = [];
  public pageSizes: any[] = [25, 50, 100, {
    text: this.translate.instant("All"),
    value: 'all'
  }];
  public pageSize = 25;
  private rtl = false;

  constructor(private cityService: CityService, private loadingService: LoadingService,
    private messages: MessageService,
    private districtService: DistrictService,
    public translate: TranslateService) {
    this.allData = this.allData.bind(this);
  }

  public ngOnInit(): void {
    this.changeDir();
    this.getCountries() ;
    this.getCitiesByCountryId();
  }

  public changeDir() {
    if (this.translate.currentLang == "ar")
      this.rtl = true;
    else
      this.rtl = false;
    this.messages.notify(this.rtl);
  }

  countryId: number=1;
  getCitiesByCountryId(): void {
    this.cityService.getCitiesByCountryId(this.countryId, this.translate.currentLang).subscribe(res => {
      this.gridData = res.datalist;
      this.gridViewArr = this.gridData;
    })
  }

  countriesArr: CountryModel[] = [];
  getCountries() {
    this.districtService.getCountries(this.translate.currentLang).subscribe(res => {
      this.countriesArr = res.datalist;
    })
  }

  changeCountry(item: CountryModel) {
    this.getCitiesByCountryId();
  }

  public onFilter(inputValue: string): void {
    this.gridViewArr = process(this.gridData, {
      filter: {
        logic: "or",
        filters: [
          {
            field: "countryName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "countryNameAr",
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
      data: process(this.gridViewArr, { sort: [{ field: 'cityName', dir: 'asc' }] }).data,
    };
    return result;
  }


}
