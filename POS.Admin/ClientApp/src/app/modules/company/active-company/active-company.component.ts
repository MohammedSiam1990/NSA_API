import { EventEmitter, Output, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { businessExceptionModel } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { AlertService } from 'src/app/_shared/services/alert.service';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { CompanyModel } from '../models/company';
import { CompanyService } from '../services/company.service';

@Component({
  selector: 'app-active-company',
  templateUrl: './active-company.component.html',
  styleUrls: ['./active-company.component.css']
})
export class ActiveCompanyComponent implements OnInit {

  @Output() onActivated: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModel") basicModel: ModalBasicComponent;
  model: CompanyModel;

  constructor(
    private translate: TranslateService,
    private notificationService: NotificationService,
    private auth: AuthService,
    private alertService: AlertService,
    private companyService: CompanyService,
    private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.model = new CompanyModel();
  }

  show(item: CompanyModel) {
    this.model = item;
    this.basicModel.show();
  }

  hideModal() {
    this.basicModel.hide();
  }

  userId: string;
  activeCompany() {
    this.userId = localStorage.getItem("userId");
    this.model.StatusID = 7;
    this.model.ApprovedBy = this.userId;
    this.model.ApprovedDate =new Date();
    this.companyService.activeCompany(this.translate.currentLang, this.model).subscribe(data => {
      if (data.success) {
        this.onActivated.emit();
        this.hideModal();
        this.notificationService.showNotification(data.message, NotificationType.Success)

      } else {
        this.hideModal();
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }

    })
  }

}
