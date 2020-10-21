import { Component, OnInit, EventEmitter, Output, ViewChild } from '@angular/core';
import { businessExceptionModel, errorsUtility } from 'src/app/_shared/common/errors.utility';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { LoginService } from '../../services/login.service';
import { VerificationEmailModel } from '../../models/login-model';
import { ConfirmVerificationCodeComponent } from '../confirm-verification-code/confirm-verification-code.component';
import { ModalBasicTwoComponent } from 'src/app/_shared/components/modal-basic-two/modal-basic-two.component';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';

@Component({
  selector: 'app-resent-email',
  templateUrl: './resent-email.component.html',
  styleUrls: ['./resent-email.component.css']
})
export class ResentEmailComponent implements OnInit {


  // @Output() onDeleted: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("confirmVerificationCode") confirmVerificationCode: ConfirmVerificationCodeComponent;
  @ViewChild("basicModelTwo") basicModelTwo: ModalBasicTwoComponent;
  verificationEmailModel: VerificationEmailModel;
  constructor(
    private route: ActivatedRoute,
    private translate: TranslateService,
    private notificationService: NotificationService,
    // private auth: AuthService,
    private loginService: LoginService,
    private loadingService: LoadingService,
    public router: Router) { }

  ngOnInit(): void {
    this.verificationEmailModel = new VerificationEmailModel();
  }


  message: any
  show(message: any) {
    this.message = message;
    this.basicModelTwo.show();
  }

  hideModal() {
    this.basicModelTwo.hide();
  }

  reSendVerificationCode() {
    // this.verificationEmailModel.email = this.loginService.lang;
    this.loadingService.showLoading();
    this.loginService.reSendVerificationCode(this.verificationEmailModel).subscribe(res => {
      this.loadingService.hideLoading();
      this.hideModal();
      this.confirmVerificationCode.show(this.verificationEmailModel.email);
      this.notificationService.showNotification(this.translate.instant('reSendVerificationCode_Successsfully'), NotificationType.Success)
    },
      err => {
        this.loadingService.hideLoading();
        this.businessException = errorsUtility.getBusinessException(err);
        this.notificationService.showNotification(this.businessException.message, NotificationType.Error);
      });
  }


}
