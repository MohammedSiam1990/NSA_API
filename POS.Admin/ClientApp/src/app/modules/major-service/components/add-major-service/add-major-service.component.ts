import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { takeWhile } from 'rxjs/operators';
import { IconService } from 'src/app/modules/service-icon/services/icon.service';
import { businessExceptionModel } from 'src/app/_shared/common/errors.utility';
import { AlertService } from 'src/app/_shared/services/alert.service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { MajorServiceTypesModel } from '../../models/major-service-model';
import { MajorServiceService } from '../../services/major-service.service';
import { DeleteServiceTypeComponent } from '../delete-service-type/delete-service-type.component';

@Component({
  selector: 'app-add-major-service',
  templateUrl: './add-major-service.component.html',
  styleUrls: ['./add-major-service.component.css']
})
export class AddMajorServiceComponent implements OnInit {

  @ViewChild("deleteServiceTypeCom") deleteServiceTypeCom: DeleteServiceTypeComponent;
  form: FormGroup;
  businessException: businessExceptionModel;
  @ViewChildren('inputs') inputs: QueryList<ElementRef>;

  public validationMessages = {
    username_required: this.translate.instant('userName_Required_Message'),
    password_required: this.translate.instant('Password_Required_Message'),
    username_pattern: this.translate.instant('username_not_valid'),
    password_minlength: this.translate.instant('Password_length')
  };

  constructor(
    private fb: FormBuilder,
    private loadingService: LoadingService,
    public translate: TranslateService,
    private alertService: AlertService,
    private notificationService: NotificationService,
    private iconService: IconService,
    private majorServiceService: MajorServiceService
  ) {

  }

  ngOnInit() {
    this.getMajorServices();
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      majorServiceTypes: this.fb.array([])
    })
  }

  createItem(): FormGroup {
    return this.fb.group({
      typeName: [''],
      typeNameAr: [''],
      majorServiceId: [''],
      majorServiceTypeId: [0]
    })
  }

  alive: boolean = true
  ngOnDestroy() {
    this.alive = false;
  }

  majorServiceTypesArr: any;
  addItem() {
    this.inputs.last.nativeElement.focus();
    this.inputs.changes.pipe(takeWhile(() => this.alive)).subscribe(() => {
      this.inputs.last.nativeElement.focus()
    })
    this.majorServiceTypesArr = this.form.get('majorServiceTypes') as FormArray;
    var lastItem = this.majorServiceTypesArr.value[this.majorServiceTypesArr.value.length - 1]
    if (!lastItem.typeName || !lastItem.typeNameAr) {
      this.notificationService.showNotification("Please Compleate Data", NotificationType.Alert)
      return;
    }
    this.majorServiceTypesArr = this.form.get('majorServiceTypes') as FormArray;
    debugger
  //  var majorServiceTypesArrNew= this.majorServiceTypesArr.value.splice(lastItem,1);
  //  majorServiceTypesArrNew.forEach(element => {
  //    if(element.typeName==lastItem.typeName )
  //    this.notificationService.showNotification(this.translate.instant, NotificationType.Alert)
  //    return;
  //  });
    this.majorServiceTypesArr.push(this.fb.group({
      typeName: [''],
      typeNameAr: [''],
      majorServiceId: [''],
      majorServiceTypeId: [0],
    }));
  }

  removeItem(index, item) {
    if (!item.majorServiceTypeId)
      (this.form.get('majorServiceTypes') as FormArray).removeAt(index);
    else
      this.deleteServiceTypeCom.show(item);
  }

  addServiceType() {
    var model = this.form.value.majorServiceTypes;
    model.forEach(element => {
      element.majorServiceId = this.serviceId;
    })
    this.majorServiceService.saveMajorServiceTypes(this.translate.currentLang, model).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success)

      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    })
  }

  serviceId: number = 1;
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

  serviceTypesArr: any;
  getServiceTypesByMajorServiceId() {
    this.createForm();
    this.majorServiceService.getMajorServiceTypesByMajorServiceId(this.serviceId, this.translate.currentLang).subscribe(res => {
      this.serviceTypesArr = res.datalist as MajorServiceTypesModel;
      this.majorServiceTypesArr = null;
      this.majorServiceTypesArr = this.form.get('majorServiceTypes') as FormArray;
      
      this.serviceTypesArr.forEach(element => {
        this.majorServiceTypesArr.push(
          this.fb.group({
            typeName: [element.typeName],
            typeNameAr: [element.typeNameAr],
            majorServiceId: [element.majorServiceId],
            majorServiceTypeId: [element.majorServiceTypeId]
          }))
      })

      if (this.majorServiceTypesArr.value.length <= 0) {
        this.form = this.fb.group({
          majorServiceTypes: this.fb.array([this.createItem()])
        })
  
      }
    })
  }

}
