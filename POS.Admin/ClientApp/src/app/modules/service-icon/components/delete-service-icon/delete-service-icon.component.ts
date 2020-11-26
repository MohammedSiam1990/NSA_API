import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { businessExceptionModel, errorsUtility } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { MajorServicesIconsModel, MajorServicesIconsViewModel } from '../../models/service-icons-model';
import { IconService } from '../../services/icon.service';


@Component({
  selector: 'app-delete-service-icon',
  templateUrl: './delete-service-icon.component.html',
  styleUrls: ['./delete-service-icon.component.css']
})
export class DeleteServiceIconComponent implements OnInit {

  @Output() onDeleted: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModel") basicModel: ModalBasicComponent;
  model: MajorServicesIconsModel;

  constructor(
    private translate: TranslateService,
    private notificationService: NotificationService,
    private auth: AuthService,
    private iconService: IconService,
    private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.model = new MajorServicesIconsModel();
  }

  show(item: MajorServicesIconsModel) {
    this.model = item;
    this.basicModel.show();
  }

  hideModal() {
    this.basicModel.hide();
  }

  userId: string;
  deleteMajorServicesIcons() {
    // var lang=this.translate.currentLang;
    // this.userId = localStorage.getItem("userId");
    debugger
    this.iconService.deleteMajorServicesIcons(this.model.IconID).subscribe(data => {
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
