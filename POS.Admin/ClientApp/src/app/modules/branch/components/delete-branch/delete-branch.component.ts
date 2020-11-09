import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { businessExceptionModel } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { BranchModel } from '../../models/branch-model';
import { BranchService } from '../../services/branch.service';

@Component({
  selector: 'app-delete-branch',
  templateUrl: './delete-branch.component.html',
  styleUrls: ['./delete-branch.component.css']
})
export class DeleteBranchComponent implements OnInit {

  @Output() onDeleted: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModel") basicModel: ModalBasicComponent;
  model: BranchModel;

  constructor(
    private translate: TranslateService,
    private notificationService: NotificationService,
    private auth: AuthService,
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
  deleteBranch() {
    this.model.StatusID = 3;
    var lang = this.translate.currentLang;
    this.userId = localStorage.getItem("userId");
    this.branchService.deleteBranch("Branches", "BranchID", this.model.BranchID, this.userId, lang).subscribe(data => {
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
