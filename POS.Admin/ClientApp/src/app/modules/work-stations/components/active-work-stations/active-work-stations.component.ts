import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { businessExceptionModel } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { AlertService } from 'src/app/_shared/services/alert.service';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { BranchWorkStationsModel } from '../../models/work-stations-model';
import { WorkStationService } from '../../services/work-station.service';

@Component({
  selector: 'app-active-work-stations',
  templateUrl: './active-work-stations.component.html',
  styleUrls: ['./active-work-stations.component.css']
})
export class ActiveWorkStationsComponent implements OnInit {

  @Output() onActivated: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModel") basicModel: ModalBasicComponent;
  model: BranchWorkStationsModel;

  constructor(
    private translate: TranslateService,
    private notificationService: NotificationService,
    private auth: AuthService,
    private alertService: AlertService,
    private workStationService: WorkStationService,
    private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.model = new BranchWorkStationsModel();
  }

  show(item: BranchWorkStationsModel) {
    this.model = item;
    this.basicModel.show();
  }

  hideModal() {
    this.basicModel.hide();
  }

  userId: string;
  activeWorkStations() {
    this.userId = localStorage.getItem("userId");
    this.model.StatusID = 7;
     this.model.ApprovedBy=this.userId
    this.workStationService.activeWorkStations(this.translate.currentLang, this.model).subscribe(data => {
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
