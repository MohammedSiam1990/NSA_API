import { Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { process } from '@progress/kendo-data-query';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { BranchService } from '../../services/branch.service';
import { BranchModel } from '../../models/branch-model';
import { DeleteBranchComponent } from '../delete-branch/delete-branch.component';
import { ActiveBranchComponent } from '../active-branch/active-branch.component';


@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.css'],
})
export class BranchListComponent implements OnInit {

  public gridData: any[] = [];
  public gridViewArr: any[] = [];
  public pageSizes: any[] = [25, 50, 100, {
    text: this.translate.instant("All"),
    value: 'all'
  }];
  public pageSize = 25;
  private rtl = false;
  @ViewChild("activeBranchComp") activeBranchComp: ActiveBranchComponent;
  @ViewChild("deleteBranchCom") deleteBranchCom: DeleteBranchComponent;

  constructor(private branchService: BranchService, private loadingService: LoadingService,
    private messages: MessageService,
    public translate: TranslateService) {
    this.allData = this.allData.bind(this);
  }

  public ngOnInit(): void {
    this.changeDir();
    this.getBranches();
  }

  public changeDir() {
    if (this.translate.currentLang == "ar")
      this.rtl = true;
    else
      this.rtl = false;
    this.messages.notify(this.rtl);
  }

  WorkStations: any;
  getBranches(): void {
    this.branchService.getBranches(this.translate.currentLang).subscribe(res => {
      this.gridData = res.datalist.Branches;
      this.gridData.forEach(element => {
        element.CreateDate=new Date(element.CreateDate);
      });
      this.getBranchesPending() ;
    })
  }

  showActive:boolean=false;
  title: string = "";
  getBranchesPending() {
    this.title = this.translate.instant("pending");
    this.showActive=false;
    var gridDataPending = this.gridData.filter(data => data.StatusID == 6);
    this.gridViewArr = gridDataPending;
    this.onFilter(this.keysearch);
  }

  getBranchesActive() {
    this.title = this.translate.instant("active");
    this.showActive=true;
    var gridDataActive = this.gridData.filter(data => data.StatusID == 7);
    this.gridViewArr = gridDataActive;
    this.onFilter(this.keysearch);
  }

  activeBranch(model: BranchModel) {
    this.activeBranchComp.show(model);
  }

  deleteBranch(model: BranchModel) {
    this.deleteBranchCom.show(model);
  }

  public onFilter(inputValue: string): void {
    this.gridViewArr = process(this.gridViewArr, {
      filter: {
        logic: "or",
        filters: [
          {
            field: "BranchNum",
            operator: "contains",
            value: inputValue
          },
          {
            field: "BranchName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "BranchNameAr",
            operator: "contains",
            value: inputValue
          },
          {
            field: "BrandName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "BrandNameAr",
            operator: "contains",
            value: inputValue
          },
          {
            field: "CityName",
            operator: "contains",
            value: inputValue
          },
          {
            field: "CityNameAr",
            operator: "contains",
            value: inputValue
          },
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
      this.getBranchesPending();
    else
      this.getBranchesActive();
  }

  public allData(): ExcelExportData {
    const result: ExcelExportData = {
      data: process(this.gridViewArr, { sort: [{ field: 'CreateDateS', dir: 'asc' }] }).data,
    };
    return result;
  }

}
