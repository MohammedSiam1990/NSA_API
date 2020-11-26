import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { businessExceptionModel, errorsUtility } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { majorServiceTypes, MajorServiceTypesModel } from '../../models/major-service-model';
import { MajorServiceService } from '../../services/major-service.service';

@Component({
  selector: 'app-delete-service-type',
  templateUrl: './delete-service-type.component.html',
  styleUrls: ['./delete-service-type.component.css']
})
export class DeleteServiceTypeComponent implements OnInit {


  @Output() onDeleted: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModel") basicModel: ModalBasicComponent;
  model: any;

  constructor(
    private translate: TranslateService,
    private notificationService: NotificationService,
    private auth: AuthService,
    private mjorServiceService: MajorServiceService,
    private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.model = new majorServiceTypes();
  }

  show(item: any) {
    this.model = item;
    this.basicModel.show();
  }

  hideModal() {
    this.basicModel.hide();
  }

  userId: string;
  deleteServiceTypes() {
    this.model.StatusID = 3;
    var lang = this.translate.currentLang;
    this.userId = localStorage.getItem("userId");
    this.mjorServiceService.deleteServiceTypes("MajorServiceTypes", "MajorServiceTypeID", this.model.majorServiceTypeId, this.userId, lang).subscribe(data => {
      if (data.success) {
        this.onDeleted.emit();
        this.hideModal();
        this.notificationService.showNotification(data.message, NotificationType.Success)

      } else {
        this.hideModal();
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    })
  }

}
