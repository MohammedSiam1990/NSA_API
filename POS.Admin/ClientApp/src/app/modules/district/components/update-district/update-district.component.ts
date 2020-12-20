import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { DistrictService } from '../../services/district.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CityModel, CountryModel, DistrictModel } from '../../models/country-model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-district',
  templateUrl: './update-district.component.html',
  styleUrls: ['./update-district.component.css']
})
export class UpdateDistrictComponent implements OnInit {

  districtId: number;
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
    private route: ActivatedRoute,
    public translate: TranslateService) {
    this.model = new DistrictModel();
    this.districtId = this.route.snapshot.params['id'];
  }

  form: FormGroup;
  ngOnInit(): void {
    this.getDistrictById();
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
      cityId: [{ value: null, disabled: true }, Validators.required],
      inActive: [false]
    })
  }


  getDistrictById() {
    this.districtService.getDistrictById(this.districtId, this.translate.currentLang).subscribe(data => {
      this.model = data.datalist;
      this.form = this.fb.group({
        districtName: [this.model.districtName, Validators.required],
        districtNameAr: [this.model.districtNameAr, Validators.required],
        cityId: [this.model.cityId, Validators.required],
        inActive: [this.model.inActive]
      })
      this.countryId = this.model.countryId;
      this.districtId = this.model.districtId;
      this.form.controls['cityId'].disable();
      this.getCitiesByCountryId();
    })

  }


  citiesArr: CityModel[] = [];
  countryId: number = 0;
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

  updateDistrict() {
    this.model = this.form.value;
    this.model.districtId = this.districtId;
    var userId = localStorage.getItem("userId");
    this.model.modifiedBy = userId;
    this.districtService.updateDistrict(this.translate.currentLang, this.model).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success)
        this.router.navigate(['/district/list']);
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    })
  }


}
