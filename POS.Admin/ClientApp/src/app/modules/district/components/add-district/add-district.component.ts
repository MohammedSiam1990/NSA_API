import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { DistrictService } from '../../services/district.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CityModel, CountryModel, DistrictModel } from '../../models/country-model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import {  Router } from '@angular/router';
import { NgSelectComponent } from '@ng-select/ng-select';


@Component({
  selector: 'app-add-district',
  templateUrl: './add-district.component.html',
  styleUrls: ['./add-district.component.css']
})
export class AddDistrictComponent implements OnInit {
  @ViewChild(NgSelectComponent) ngSelectComponent: NgSelectComponent;

  model: DistrictModel;
  public validationMessages = {
    districtName_required: this.translate.instant('field_is_Required'),
    districtNameAr_required: this.translate.instant('field_is_Required'),
    cityId_required: this.translate.instant('field_is_Required')
  };

  constructor(private districtService: DistrictService, private loadingService: LoadingService,
    private messages: MessageService,
    private fb: FormBuilder,
    private notificationService: NotificationService,
    private router: Router,
    public translate: TranslateService) {
    this.model = new DistrictModel();
  }

  form: FormGroup;
  ngOnInit(): void {
    this.createForm();
    this.getCountries();
  }

  countriesArr: CountryModel[] = [];
  getCountries() {
    this.districtService.getCountries(this.translate.currentLang).subscribe(res => {
      this.countriesArr = res.datalist;
    })
  }

  createForm() {
    this.form = this.fb.group({
      districtName: ['', Validators.required],
      districtNameAr: ['', Validators.required],
      cityId: [null, Validators.required],
      inActive: [false]
    })
  }

  citiesArr: CityModel[] = [];
  countryId: number;
  cityId: number;
  getCitiesByCountryId() {
    this.districtService.getCitiesByCountryId(this.countryId, this.translate.currentLang).subscribe(res => {
      this.citiesArr = res.datalist;
    })
  }

  changeCountry(item: CountryModel) {
    this.countryId = item.countryId;
    this.form.controls.cityId.setValue(null, Validators.required);
    this.getCitiesByCountryId();
  }

  addDistrict() {
    this.model = this.form.value;
    var userId = localStorage.getItem("userId");
    this.model.insertedBy = userId;
    this.districtService.addDistract(this.translate.currentLang, this.model).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success);
        debugger
       this.ngSelectComponent.clearModel();
        this.form.reset();
        // this.router.navigate(['/district/list']);
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    })
  }

}
