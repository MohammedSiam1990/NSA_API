import { Component, ViewChild, ElementRef, AfterViewInit, ViewEncapsulation, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, Event, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { NotificationService } from './_shared/services/notification.service';
import { TranslateService } from '@ngx-translate/core';
import { MenuService } from './_shared/services/menu.service';
import { NotificationType } from './_shared/components/notification/notification.component';
import { NavService } from './_shared/services/nav.service';
import { VERSION } from '@angular/material/core';
import { LoadingService } from './_shared/services/loading.service';
import { TooltipConfig } from 'ngx-bootstrap/tooltip';
import { AuthService } from './_shared/services/auth/authr.Service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [{ provide: TooltipConfig, useFactory: getAlertConfig }]

})
export class AppComponent implements OnInit {
@ViewChild('appDrawer') appDrawer: ElementRef;
isExpanded: boolean = false;
version = VERSION;
arabicLang: boolean = false;
loading: boolean = false;
isAuthorized: boolean = false;
showAcivityPageLeftMenu: boolean = false;
isNotificationDetailsPage: boolean = false;
isApplicationModule: boolean = false;
isDashboard: boolean = true;
isLoginPage: boolean = false;
showHeader: boolean = false;
showSideMenu: boolean = false;
constructor(private authService: AuthService,
  private toastr: ToastrService,
  private router: Router,
  private notificationService: NotificationService,
  public translate: TranslateService,
  private menuService: MenuService,
  public navService: NavService,
  private loadingService: LoadingService
) {


  router.events.subscribe((routerEvent: Event) => {
    this.checkRouterEvent(routerEvent);
  });
  loadingService.isLoading.subscribe(isLoading => {
    this.loading = isLoading;
  });
  this.isAuthorized = this.authService.isAuthenticated();
  this.showSideMenu = this.authService.isAuthenticated();
  this.router.events.subscribe((event: Event) => {
    switch (true) {
      case event instanceof NavigationStart: {
        this.loading = true;
        break;
      }

      case event instanceof NavigationEnd:
      case event instanceof NavigationCancel:
      case event instanceof NavigationError: {
        setTimeout(() => {
          this.loading = false;
        }, 1500);
        this.menuService.activeItemChanged.emit();
        break;
      }
      default: {
        break;
      }
    }
  });

  notificationService.showNotificationEvent.subscribe(event => {
    this.showNotificationMessage(event.message, event.type);
  });

  notificationService.hideNotificationEvent.subscribe(event => {
    this.hideNotificationMessage();
  });

  // this.translate.addLangs(['en', 'ar']);
  // if (localStorage.getItem('locale')) {
  //   const browserLang = localStorage.getItem('locale');
  //   this.translate.use(browserLang.match(/en|ar/) ? browserLang : 'en');
  // } else {
  //   localStorage.setItem('locale', 'en');
  //   this.translate.setDefaultLang('en');
  // }
  translate.addLangs(['en','ar']);
  translate.setDefaultLang('en');

}

changeLang(language: string) {
  localStorage.setItem('locale', language);
  this.translate.use(language);
}

switchLang(lang: string) {
  this.translate.use(lang);
}

// Notification
MyType = NotificationType;
Type: NotificationType;
Message: string = "";
showNotification: boolean = false;
animateIn: boolean = false;
animateOut: boolean = false;

showNotificationMessage(message: string, type: NotificationType) {
  switch (type) {
    case NotificationType.Success:
      this.toastr.success("", message);
      break;
    case NotificationType.Error:
      this.toastr.error("", message);
      break;
    case NotificationType.Alert:
      this.toastr.warning("", message);
      break;
  }
}

hideNotificationMessage() {
  this.showNotification = false;
}

ngOnInit() {

  this.translate.setDefaultLang('en');
  this.notificationService.showNotificationEvent.subscribe(event => {
    this.showNotificationMessage(event.message, event.type);
  });

  this.notificationService.hideNotificationEvent.subscribe(event => {
    this.hideNotificationMessage();
  });

  this.translate.setDefaultLang('en');
  this.translate.use(this.authService.getCurrentLanguage());
  if (this.authService.getCurrentLanguage() == "ar") {
    this.authService.setArabicLanguageStyle();
    this.arabicLang = true;
  }

  else {
    this.authService.removeArabicStyle();
    this.arabicLang = false
  }
}

openMun() {
  this.isExpanded = !this.isExpanded
  this.navService.isExpanded = this.isExpanded;
}

ngAfterViewInit() {
  this.navService.appDrawer = this.appDrawer;
}

isAuthenticated() {
  return this.authService.isAuthenticated();
}

checkRouterEvent(routerEvent: Event): void {
  if (routerEvent instanceof NavigationStart) {
    this.isAuthorized = this.authService.isAuthenticated();
    this.loadingService.showLoading();
    this.isLoginPage = routerEvent.url.toLowerCase().indexOf('/login') > -1 ||
      routerEvent.url.toLowerCase().indexOf('/signup') > -1 ||
      routerEvent.url.toLowerCase().indexOf('/account/problem') > -1;
    this.showHeader = this.isAuthenticated && !this.isApplicationModule;
    if (!this.isLoginPage) {
      if (!this.authService.isAuthenticated())
        this.router.navigate(['/login']);
    }
    else {
      if (this.authService.isAuthenticated())
        this.router.navigate(['/home']);
    }
  }

  if (routerEvent instanceof NavigationEnd ||
    routerEvent instanceof NavigationCancel ||
    routerEvent instanceof NavigationError) {
    this.showSideMenu = this.authService.isAuthenticated();
    this.loadingService.hideLoading();
  }

}


showSpinner() {
  this.loading = true;
  setTimeout(() => { this.loading = false; }, 3000);
}

}

export function getAlertConfig(): TooltipConfig {
return Object.assign(new TooltipConfig(), {
  placement: 'right',
  container: 'body'
});
}
