import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmVerificationCodeComponent } from 'src/app/modules/login/components/confirm-verification-code/confirm-verification-code.component';
import { VerificationEmailModel } from 'src/app/modules/login/models/login-model';
import { LoginService } from 'src/app/modules/login/services/login.service';
import { businessExceptionModel, errorsUtility } from 'src/app/_shared/common/errors.utility';
import { ModalBasicTwoComponent } from 'src/app/_shared/components/modal-basic-two/modal-basic-two.component';
import { AlertService } from 'src/app/_shared/services/alert.service';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  businessException: businessExceptionModel;
  @ViewChild("confirmVerificationCode") confirmVerificationCode: ConfirmVerificationCodeComponent;
  @ViewChild("basicModelTwo") basicModelTwo: ModalBasicTwoComponent;
  verificationEmailModel: VerificationEmailModel;
  notificationService: any;
  constructor(
    private formBuilder: FormBuilder,
    private loadingService: LoadingService,
    private route: ActivatedRoute,
    public translate: TranslateService,
    private alertService: AlertService,
    private loginService: LoginService,
    private auth: AuthService,
    public router: Router,
    private notification: NotificationService
  ) { }

  ngOnInit(): void {
    debugger
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
    this.loginService.sendEmail(this.verificationEmailModel).subscribe(res => {
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
  switchLang(lang: string) {
    this.loadingService.showLoading();
    if (lang == "en") {
      this.loginService.position = "start"
    }
    else {
      this.loginService.position = "end"
    }
    this.auth.setCurrentLanguage(lang);
    this.translate.use(lang);
    setTimeout(() => {
      this.loadingService.hideLoading();
    }, 500);
    this.refresh();
  }

  refresh(): void {
    window.location.reload();
  }

}
