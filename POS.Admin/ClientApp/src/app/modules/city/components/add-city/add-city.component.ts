import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CityModel, CountryModel } from 'src/app/modules/district/models/country-model';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { CityService } from '../../services/city.service';
import { MessageService } from '@progress/kendo-angular-l10n';
import { DistrictService } from 'src/app/modules/district/services/district.service';

@Component({
  selector: 'app-add-city',
  templateUrl: './add-city.component.html',
  styleUrls: ['./add-city.component.css']
})
export class AddCityComponent implements OnInit {

  model: CityModel;
  public validationMessages = {
    cityName_required: this.translate.instant('field_is_Required'),
    cityNameAr_required: this.translate.instant('field_is_Required'),
    countryId_required: this.translate.instant('field_is_Required')
  };

  constructor(private cityService: CityService, private loadingService: LoadingService,
    private messages: MessageService,
    private fb: FormBuilder,
    private districtService: DistrictService,
    private notificationService: NotificationService,
    private router: Router,
    public translate: TranslateService) {
    this.model = new CityModel();
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
      cityName: ['', Validators.required],
      cityNameAr: ['', Validators.required],
      countryId: [null, Validators.required],
    })
  }

  countryId: number;
  changeCountry(item: CountryModel) {
    this.countryId = item.countryId;
    this.form.controls.cityId.setValue(null, Validators.required);
  }

  saveCity() {
    this.model = this.form.value;
    var userId = localStorage.getItem("userId");
    this.model.insertedBy = userId;
    this.cityService.saveCity(this.translate.currentLang, this.model).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success)
        this.form.reset();
        // this.router.navigate(['/city/list']);
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    })
  }

}
