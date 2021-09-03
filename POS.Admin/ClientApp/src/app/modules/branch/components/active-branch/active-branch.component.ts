import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { CompanyService } from 'src/app/modules/company/services/company.service';
import { businessExceptionModel } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { AlertService } from 'src/app/_shared/services/alert.service';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { BranchModel } from '../../models/branch-model';
import { BranchService } from '../../services/branch.service';

@Component({
  selector: 'app-active-branch',
  templateUrl: './active-branch.component.html',
  styleUrls: ['./active-branch.component.css']
})
export class ActiveBranchComponent implements OnInit {

  @Output() onActivated: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModel") basicModel: ModalBasicComponent;
  model: BranchModel;

  constructor(
    private translate: TranslateService,
    private notificationService: NotificationService,
    private auth: AuthService,
    private alertService: AlertService,
    private branchService: BranchService,
    private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.model = new BranchModel();
  }

  show(item: BranchModel) {
    this.model = item;
    this.basicModel.show();
  }

  hideModal() {
    this.basicModel.hide();
  }

  userId: string;
  activeBranch() {
    this.userId = localStorage.getItem("userId");
    this.model.StatusID = 7;
    this.model.ApprovedBy = this.userId;
    this.model.ApprovedDate =new Date();
    this.branchService.activeBranch(this.translate.currentLang, this.model).subscribe(data => {
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
