import { Component, OnInit, ViewChild } from '@angular/core';
import { businessExceptionModel, errorsUtility } from 'src/app/_shared/common/errors.utility';
import { VerificationEmailModel, EmailConfirmedModel } from '../../models/login-model';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { LoginService } from '../../services/login.service';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { FormGroup } from '@angular/forms';
import { ModalBasicTwoComponent } from 'src/app/_shared/components/modal-basic-two/modal-basic-two.component';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';

@Component({
  selector: 'app-confirm-verification-code',
  templateUrl: './confirm-verification-code.component.html',
  styleUrls: ['./confirm-verification-code.component.css']
})
export class ConfirmVerificationCodeComponent implements OnInit {

  // @Output() onDeleted: EventEmitter<any> = new EventEmitter();
  businessException: businessExceptionModel;
  @ViewChild("basicModelTwo") basicModelTwo: ModalBasicTwoComponent;
  verificationEmailModel: VerificationEmailModel;
  form: FormGroup;
  model: EmailConfirmedModel;
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
    this.model = new EmailConfirmedModel();
  }


  email: string;
  show(email: string) {
    this.email = email;
    this.basicModelTwo.show();
  }

  hideModal() {
    this.basicModelTwo.hide();
  }

  confirmCode: any;
  emailConfirmedModel() {
    this.model.confirmCode = this.confirmCode;
    this.model.email = this.email;
    // this.loadingService.showLoading();
    // this.signUpService.updateEmailConfirmed(this.model).subscribe(res => {
    //   this.notificationService.showNotification(this.translate.instant('Add Email Confirm Successsfully'), NotificationType.Success)
    //   this.hideModal();
    //   this.loadingService.hideLoading();
    // }, error => {
    //   this.loadingService.hideLoading();
    //   var businessException = errorsUtility.getBusinessException(error);
    //   this.notificationService.showNotification(businessException.message, NotificationType.Error);
    // })

  }

  verificationEmail() {
    this.loadingService.showLoading();
    this.verificationEmailModel.email = this.email;
    // this.signUpService.reSendVerificationCode(this.verificationEmailModel).subscribe(res => {
    //   this.loadingService.hideLoading();
    // }, error => {
    //   this.loadingService.hideLoading();
    //   var businessException = errorsUtility.getBusinessException(error);
    //   this.notificationService.showNotification(businessException.message, NotificationType.Error);
    // })
  }

}

