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
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertService } from 'src/app/_shared/services/alert.service';

@Component({
  selector: 'app-resent-email',
  templateUrl: './resent-email.component.html',
  styleUrls: ['./resent-email.component.css']
})
export class ResentEmailComponent implements OnInit {

  email: any;
  form: FormGroup;
  businessException: businessExceptionModel;
  @ViewChild("confirmVerificationCode") confirmVerificationCode: ConfirmVerificationCodeComponent;
  @ViewChild("basicModelTwo") basicModelTwo: ModalBasicTwoComponent;
  verificationEmailModel: VerificationEmailModel;
  public validationMessages = {
    email_required: this.translate.instant('email_is_required'),
    email_pattern: this.translate.instant('email_not_valid'),
  };
  constructor(
    private fb: FormBuilder,
    private loadingService: LoadingService,
    private loginService: LoginService,
    public translate: TranslateService,
    private authService: AuthService,
        private router: Router,
    private notificationService: NotificationService
  ) { }

  ngOnInit(): void {
    this.verificationEmailModel = new VerificationEmailModel();
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.pattern('^([a-zA-Z0-9_.+-]+)@([a-zA-Z0-9-]+[\.][a-zA-Z0-9-.]{1,})$')]],
    })
  }
  
  reSendEmail() {
    // this.verificationEmailModel.email = this.loginService.lang;
    this.verificationEmailModel.email =this.form.value.email;
    this.verificationEmailModel.lang=this.translate.currentLang;
    debugger
    this.loadingService.showLoading();
    this.loginService.sendEmail(this.verificationEmailModel).subscribe(res => {
      this.loadingService.hideLoading();
      this.notificationService.showNotification(this.translate.instant('reSendVerificationCode_Successsfully'), NotificationType.Success),
      this.router.navigate(['/login/confirm-email']);
    },
      err => {
        this.loadingService.hideLoading();
        this.businessException = errorsUtility.getBusinessException(err);
        this.notificationService.showNotification(this.businessException.message, NotificationType.Error);
      });
  }
  
  switchLanguage() {
    if (this.translate.currentLang == "ar") {
      this.loadingService.showLoading();
      this.authService.setCurrentLanguage("en");
      this.translate.use("en");
      setTimeout(() => {
        this.loadingService.hideLoading();
      },500);
    } else {
      this.loadingService.showLoading();
      this.authService.setCurrentLanguage("ar");
      this.translate.use("ar");
      setTimeout(() => {
        this.loadingService.hideLoading();
      }, 500);
    }
    this.refresh();
  }

  refresh(): void {
    window.location.reload();
  }


}
