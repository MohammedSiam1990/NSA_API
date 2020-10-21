import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalBasicComponent } from 'src/app/_shared/components/modal-basic/modal-basic.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { VerificationEmailModel } from '../../models/login-model';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { LoginService } from '../../services/login.service';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { Router } from '@angular/router';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { errorsUtility } from 'src/app/_shared/common/errors.utility';
import { ModalBasicTwoComponent } from 'src/app/_shared/components/modal-basic-two/modal-basic-two.component';

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css']
})
export class ConfirmEmailComponent implements OnInit {

  email: any;
  @ViewChild("basicModelTwo") basicModelTwo: ModalBasicTwoComponent;
  form: FormGroup;
  public validationMessages = {
    email_required: this.translate.instant('email is required'),
    email_pattern: this.translate.instant('email not valid'),
  };

  verificationEmailModel: VerificationEmailModel;
  constructor(private fb: FormBuilder,
    private loadingService: LoadingService,
    private loginService: LoginService,
    public translate: TranslateService,
    // private auth: AuthService,
    private router: Router,
    private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.verificationEmailModel = new VerificationEmailModel();
    this.createForm();
  }

  show() {
    this.verificationEmailModel = new VerificationEmailModel();
    this.createForm();
    this.basicModelTwo.show();
  }

  hideModal() {
    this.basicModelTwo.hide();
  }

  createForm() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.pattern('^([a-zA-Z0-9_.+-]+)@([a-zA-Z0-9-]+[\.][a-zA-Z0-9-.]{1,})$')]],
    })
  }


  verificationEmail() {
    // this.loginService.email = this.form.value.email;
    this.verificationEmailModel = this.form.value;
    this.loadingService.showLoading();
    this.loginService.reSendVerificationCode(this.verificationEmailModel).subscribe(res => {
      // this.loadingService.hideLoading();
      this.form
      this.router.navigate(['/login/change-password']);

    }, error => {
      this.loadingService.hideLoading();
      var businessException = errorsUtility.getBusinessException(error);
      this.notificationService.showNotification(businessException.message, NotificationType.Error);
    })
  }


}
