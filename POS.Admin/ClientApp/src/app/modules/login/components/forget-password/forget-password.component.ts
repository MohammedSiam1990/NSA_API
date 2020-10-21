import { Component, OnInit, ViewChild } from '@angular/core';
import { businessExceptionModel, errorsUtility } from 'src/app/_shared/common/errors.utility';
import { FormBuilder, FormGroup, Validators, ValidationErrors, AbstractControl, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { LoginService } from '../../services/login.service';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';
import { RestPasswordModel } from '../../models/login-model';
import { LoadingService } from 'src/app/_shared/services/loading.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.css']
})
export class ForgetPasswordComponent implements OnInit {

  isArabicLanguage: boolean = false;
  passwordCtrl: AbstractControl;
  confirmPasswordCtrl: AbstractControl;
  returnUrl: string;
  businessException: businessExceptionModel;
  restPasswordModel: RestPasswordModel;
  form: FormGroup;
  password: FormControl;
  confirmPassword: FormControl;
  public validationMessages = {
    Password_required: this.translate.instant('Password is required'),
    Password_pattern: this.translate.instant('Password_conditions'),
    Password_minlength: this.translate.instant('Password_length'),
    confirmPassword_required: this.translate.instant('Confirmation password is required'),
    confirmPassword_pattern: this.translate.instant('Password_conditions'),
    confirmPassword_isMatching: this.translate.instant('insert_same_again')
  };

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    public translate: TranslateService,
    private notificationService: NotificationService,
    private loginService: LoginService,
    private auth: AuthService,
    private loadingService: LoadingService,
    public router: Router,
    private notification: NotificationService,
    private fb: FormBuilder,
    
  ) { }

  ngOnInit() {
    this.createForm();
    this.restPasswordModel = new RestPasswordModel();
    this.translate.setDefaultLang('en');
    this.translate.use(this.auth.getCurrentLanguage());
    if (this.auth.getCurrentLanguage() == "ar") {
      this.auth.setArabicLanguageStyle();
      this.isArabicLanguage = true;
    }

    else {
      this.auth.removeArabicStyle();
      this.isArabicLanguage = false
    }
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  switchLang(lang: string) {

    if (lang == "en") {
      this.loginService.position = "start"
    }
    else {
      this.loginService.position = "end"
    }
    this.auth.setCurrentLanguage(lang);
    this.translate.use(lang);
  }

  position: any = "start";
  changeLanguage() {
    if (this.translate.currentLang == "en") {
      this.position == "start"
      this.auth.setCurrentLanguage("ar");
    }
    else {
      this.position == "end"
      this.auth.setCurrentLanguage("en");
    }
  }

  confirmCode: string;
  createForm() {
    this.form = this.fb.group({
      confirmCode: [],
      passwordGroup: this.fb.group({
        Password: ['', [Validators.required, Validators.minLength(8), Validators.pattern('(?=.*[a-zA-Z])(?=.*[a-zA-Z])(?=.*[0-9]).{8,20}')]],
        confirmPassword: ['', [Validators.required, this.matchValues('Password')]]
      })
    })
    this.passwordCtrl = this.form.get('passwordGroup.Password') as FormControl;
    this.confirmPasswordCtrl = this.form.get('passwordGroup.confirmPassword') as FormControl;
  }

  changePassword() {
    this.loadingService.showLoading();
    var restPasswordModel = new RestPasswordModel();
    // restPasswordModel.email = this.loginService.email;
    restPasswordModel.confirmCode = this.form.value.confirmCode;
    restPasswordModel.password = this.passwordCtrl.value;
    restPasswordModel.confirmPassword = this.confirmPasswordCtrl.value;
    this.loginService.forgetPassword(restPasswordModel).subscribe(res => {
      this.loadingService.hideLoading();
      this.notificationService.showNotification(this.translate.instant('change password Successsfully'), NotificationType.Success)

      this.router.navigate(['/login']);
    }, error => {
      this.loadingService.hideLoading();
      var businessException = errorsUtility.getBusinessException(error);
      this.notificationService.showNotification(businessException.message, NotificationType.Error);
    })
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


}
export function removeSpaces(control: AbstractControl) {
  if (control && control.value && !control.value.replace(/\s/g, '').length) {
    control.setValue('');
  }
  return null;
}