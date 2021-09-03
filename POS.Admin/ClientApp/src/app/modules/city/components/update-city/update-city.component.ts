import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { CityModel, CountryModel } from 'src/app/modules/district/models/country-model';
import { DistrictService } from 'src/app/modules/district/services/district.service';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { CityService } from '../../services/city.service';
import { MessageService } from '@progress/kendo-angular-l10n';

@Component({
  selector: 'app-update-city',
  templateUrl: './update-city.component.html',
  styleUrls: ['./update-city.component.css']
})
export class UpdateCityComponent implements OnInit {

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
    private route: ActivatedRoute,
    public translate: TranslateService) {
    this.model = new CityModel();
    
    this.cityId = this.route.snapshot.params['id'];
  }

  form: FormGroup;
  ngOnInit(): void {
    this.createForm();
    this.getCountries();
    
    this.getCityById();
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
      countryId: [{value:null,disabled:true}, Validators.required],
    })
  }

  saveCity() {
    this.model = this.form.value;
    this.model.cityId = this.cityId;
    var userId = localStorage.getItem("userId");
    this.model.modifiedBy = userId;
    this.cityService.saveCity(this.translate.currentLang, this.model).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success)
        this.router.navigate(['/city/list']);
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    })
  }


  cityId: number;
  getCityById() {
    this.cityService.getCityById(this.cityId, this.translate.currentLang).subscribe(data => {
      this.model = data.datalist;
      this.cityId = this.model.cityId;
      this.form = this.fb.group({
        cityName: [this.model.cityName, Validators.required],
        cityNameAr: [this.model.cityNameAr, Validators.required],
        countryId: [this.model.countryId, Validators.required],
      })
    })
  }


}
