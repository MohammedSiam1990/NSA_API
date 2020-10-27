import { Component, OnInit, ViewChild } from '@angular/core';
import { LoginModel } from 'src/app/_shared/models/loginModel';
import { errorsUtility, businessExceptionModel } from 'src/app/_shared/common/errors.utility';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { TranslateService } from '@ngx-translate/core';
import { LoginService } from '../../services/login.service';
import { AuthenticateModel } from '../../models/login-model';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { ConfirmEmailComponent } from '../confirm-email/confirm-email.component';
import { ResentEmailComponent } from '../resent-email/resent-email.component';
import { AlertService } from 'src/app/_shared/services/alert.service';
import { AuthService } from 'src/app/_shared/services/auth/authr.Service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isArabicLanguage: boolean = false;
  loginForm: FormGroup;
  returnUrl: string;
  businessException: businessExceptionModel;
  // @ViewChild("confirmEmailComp") confirmEmailComp: ConfirmEmailComponent;
  @ViewChild("resentEmailCom") resentEmailCom: ResentEmailComponent;

  public validationMessages = {
    username_required: this.translate.instant('userName_Required_Message'),
    password_required: this.translate.instant('Password_Required_Message'),
    username_pattern: this.translate.instant('username_not_valid'),
    password_minlength: this.translate.instant('Password_length')
  };

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
  ) {

  }

  ngOnInit() {
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

    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.pattern('^([a-zA-Z0-9_.+-]+)@([a-zA-Z0-9-]+[\.][a-zA-Z0-9-.]{1,})$')]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      rememberMe: [],
    });
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }


  username: string;
  lang: string;
  password: string;
  RememberMe: boolean;
  login() {
    var myloginModel = new AuthenticateModel();
    myloginModel = {
      username: this.loginForm.controls.username.value,
      lang: this.translate.currentLang,
      password: this.loginForm.controls.password.value,
      RememberMe: this.loginForm.controls.rememberMe.value,
      userType: 2
    };

    this.loginService.username = myloginModel.username;
    this.loginService.Login(myloginModel).subscribe(
      data => {

        if (data.userId == null || data.token == null) {
          this.alertService.error(data.message);
        } else {
          var rememberMe = this.loginForm.controls.rememberMe.value;
          this.loginService.companyId = data.companyId;
          this.auth.setAuthorizationToken(data, rememberMe);
          this.router.navigate(['/home']);
        }
      },
      err => {
        this.loadingService.hideLoading();
        this.businessException = errorsUtility.getBusinessException(err);
        if (err.error.emailConfirmedStatus == false) {

        }
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
    },500);
    this.refresh();
  }

  refresh(): void {
    window.location.reload();
  }

}
