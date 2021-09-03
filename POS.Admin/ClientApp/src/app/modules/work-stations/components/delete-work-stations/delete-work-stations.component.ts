import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { businessExceptionModel, errorsUtility } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { BranchWorkStationsModel } from '../../models/work-stations-model';
import { WorkStationService } from '../../services/work-station.service';

@Component({
  selector: 'app-delete-work-stations',
  templateUrl: './delete-work-stations.component.html',
  styleUrls: ['./delete-work-stations.component.css']
})
export class DeleteWorkStationsComponent implements OnInit {

  @Output() onDeleted: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModel") basicModel: ModalBasicComponent;
  model: BranchWorkStationsModel;

  constructor(
    private translate: TranslateService,
    private notificationService: NotificationService,
    private auth: AuthService,
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
  deleteWorkStations() {
    this.model.StatusID = 3;
    var lang=this.translate.currentLang;
    this.userId = localStorage.getItem("userId");
    this.workStationService.deleteWorkStations("BranchWorkStations", "BranchWorkstationID", this.model.BranchWorkstationID, this.userId,lang).subscribe(data => {
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
