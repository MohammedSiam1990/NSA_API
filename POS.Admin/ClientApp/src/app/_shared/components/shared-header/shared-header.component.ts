import { Component, OnInit, ViewChild, Input, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { environment } from 'src/environments/environment';
import { MenuService } from '../../services/menu.service';
import { NavService } from '../../services/nav.service';
import { LoadingService } from '../../services/loading.service';
import { errorsUtility } from '../../common/errors.utility';
import { NotificationType, NotificationService } from '../../services/notification.service';
import { TooltipConfig } from 'ngx-bootstrap/tooltip';
import { AuthService } from '../../services/auth/authr.Service';
import { ChangePasswordService } from '../../services/change-password.service';


@Component({
  selector: 'app-shared-header',
  templateUrl: './shared-header.component.html',
  styleUrls: ['./shared-header.component.css'],
  providers: [{ provide: TooltipConfig, useFactory: getAlertConfig }]
})
export class SharedHeaderComponent implements OnInit {
  isShowMenu: boolean = false;
  public collapsed = false;
  isExpanded: boolean = true;
  isAuthenticated: boolean = false;
  hasSocialGroups: boolean = false;
  userName: string;
  userImage: string = "";
  companyId: any = parseInt(localStorage.getItem("companyId"));
  isArabicLanguage: boolean = false;
  completionPercentage: number = 0;
  leftProgressClass: string = "progress-bar5";
  rightProgressClass: string = "progress-bar5";
  mainProfile: any;
  environmentVars = environment;
  companyNameEn: string;

  constructor(
    private translate: TranslateService,
    private router: Router,
    private authService: AuthService,
    public navService: NavService,
    private changeDetectorRef: ChangeDetectorRef,
    public changePasswordService: ChangePasswordService,
    private loadingService: LoadingService,
    private notificationService: NotificationService,
  ) { }

  ngOnInit() {
    this.userName = localStorage.getItem("userName");
    this.companyNameEn = localStorage.getItem("companyNameEn");

    if (this.translate.currentLang == "ar")
      this.isArabicLanguage = true;
    else
      this.isArabicLanguage = false;
  }


  openMun() {
    this.isExpanded = !this.isExpanded
    this.navService.isExpanded = this.isExpanded;
  }

  showChangePass() {
    this.changePasswordService.showChangePassword = true;
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

  logout() {
    this.authService.logout();
  }
  
}

export function getAlertConfig(): TooltipConfig {
  return Object.assign(new TooltipConfig(), {
    placement: 'right',
    container: 'body'
  });
}