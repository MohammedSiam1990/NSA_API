import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { LoginService } from 'src/app/modules/login/services/login.service';
import { businessExceptionModel, errorsUtility } from '../../common/errors.utility';
import { ChangePasswordBindingModel } from '../../models/changePassword-model';
import { AlertService } from '../../services/alert.service';
import { AuthService } from '../../services/auth/authr.Service';
import { ChangePasswordService } from '../../services/change-password.service';
import { LoadingService } from '../../services/loading.service';
import { NotificationService, NotificationType } from '../../services/notification.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  public validationMessages = {
    oldPassword_required: this.translate.instant('oldPassword_is_required'),
    Password_required: this.translate.instant('NewPassword_is_Required'),
    Password_pattern: this.translate.instant('Password_conditions'),
    Password_minlength: this.translate.instant('Password_length'),
    confirmPassword_required: this.translate.instant('confirmPassword_required'),
    confirmPassword_pattern: this.translate.instant('Password_conditions'),
    confirmPassword_isMatching: this.translate.instant('confirmPassword_isMatching')
  };

  isArabicLanguage: boolean = false;
  passwordCtrl: AbstractControl;
  confirmPasswordCtrl: AbstractControl;
  returnUrl: string;
  businessException: businessExceptionModel;
  form: FormGroup;
  newPassword: FormControl;
  confirmPassword: FormControl;
  changePasswordBindingModel: ChangePasswordBindingModel;
  constructor(private fb: FormBuilder, private route: ActivatedRoute,
    public translate: TranslateService,
    private notificationService: NotificationService,
    public changePasswordService: ChangePasswordService,
    private auth: AuthService,
    private loadingService: LoadingService,
    private alertService: AlertService,
    public router: Router,
    private notification: NotificationService,) { }

  ngOnInit(): void {
    this.createForm();
  }

  lang: string;
  createForm() {
    this.form = this.fb.group({
      oldPassword: ['', Validators.required],
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

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }


  changePassword() {
    // this.loadingService.showLoading();
    var changePasswordBindingModel = new ChangePasswordBindingModel();
    changePasswordBindingModel.lang = this.translate.currentLang;
    changePasswordBindingModel.oldPassword = this.form.value.oldPassword;
    changePasswordBindingModel.newPassword = this.passwordCtrl.value;
    changePasswordBindingModel.confirmPassword = this.confirmPasswordCtrl.value;
    this.changePasswordService.changePassword(changePasswordBindingModel).subscribe(res => {
      // this.loadingService.hideLoading();
      if (res.success)

        this.alertService.success(res.message);
      else
      this.alertService.error(res.message);
    }, error => {
      // this.loadingService.hideLoading();
      var businessException = errorsUtility.getBusinessException(error);
      this.notificationService.showNotification(businessException.message, NotificationType.Error);
    })
  }

  closeChangePass() {
    this.changePasswordService.showChangePassword = false;
  }

}
