import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmVerificationCodeComponent } from 'src/app/modules/login/components/confirm-verification-code/confirm-verification-code.component';
import { ResetPasswordViewModel, VerificationEmailModel } from 'src/app/modules/login/models/login-model';
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
  resetPasswordViewModel: ResetPasswordViewModel;
  token: string;
  form: FormGroup;
  passwordCtrl: AbstractControl;
  confirmPasswordCtrl: AbstractControl;
  returnUrl: string;
  newPassword: FormControl;
  confirmPassword: FormControl;
  public validationMessages = {
    email_required: this.translate.instant('email_is_required'),
    email_pattern: this.translate.instant('email_not_valid'),
    Password_required: this.translate.instant('NewPassword_is_Required'),
    Password_pattern: this.translate.instant('Password_conditions'),
    Password_minlength: this.translate.instant('Password_length'),
    confirmPassword_required: this.translate.instant('confirmPassword_required'),
    confirmPassword_pattern: this.translate.instant('Password_conditions'),
    confirmPassword_isMatching: this.translate.instant('confirmPassword_isMatching')
  };
  constructor(
    private formBuilder: FormBuilder,
    private loadingService: LoadingService,
    private ativatedRoute: ActivatedRoute,
    public translate: TranslateService,
    private alertService: AlertService,
    private loginService: LoginService,
    private auth: AuthService,
    public router: Router,
    private fb: FormBuilder,
    private notificationService: NotificationService,
  ) { }

  ngOnInit(): void {
    this.ativatedRoute.queryParams.subscribe(param => {
      this.token = param["Resetcode"];
    })
    this.createForm();
    this.resetPasswordViewModel = new ResetPasswordViewModel();
    this.resetPasswordViewModel.email = this.token;
  }

  createForm() {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.pattern('^([a-zA-Z0-9_.+-]+)@([a-zA-Z0-9-]+[\.][a-zA-Z0-9-.]{1,})$')]],
      passwordGroup: this.fb.group({
        newPassword: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', [Validators.required, this.matchValues('newPassword')]]
      })
    })
    this.passwordCtrl = this.form.get('passwordGroup.newPassword') as FormControl;
    this.confirmPasswordCtrl = this.form.get('passwordGroup.confirmPassword') as FormControl;
  }

  public matchValues(
    matchTo: string // name of the control to match to
  ): (AbstractControl) => ValidationErrors | null {
    return (control: AbstractControl): ValidationErrors | null => {
      return !!control.parent &&
        !!control.parent.value &&
        control.value === control.parent.controls[matchTo].value
        ? null
        : { isMatching: true };
    };
  }

  resetPassword() {
    this.loadingService.showLoading();
    this.resetPasswordViewModel.email = this.form.value.email;
    this.resetPasswordViewModel.password = this.passwordCtrl.value;
    this.resetPasswordViewModel.Resetcode = this.token;
    this.loginService.resetPassword(this.resetPasswordViewModel, this.translate.currentLang).subscribe(data => {
      this.loadingService.hideLoading();
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success);
        this.router.navigate(['/login']);
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error);
      }
    })
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
