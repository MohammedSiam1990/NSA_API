import { Component, HostBinding, Input, OnInit, ChangeDetectorRef, OnDestroy, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { animate, state, style, transition, trigger, query, stagger } from '@angular/animations';
import { NavService } from '../../services/nav.service';
import { MatSidenav } from '@angular/material/sidenav';
import { MediaMatcher } from '@angular/cdk/layout';
import { MenuService } from '../../services/menu.service';
import { environment } from 'src/environments/environment';
import { TooltipConfig } from 'ngx-bootstrap/tooltip';
import { AuthService } from '../../services/auth/authr.Service';
import { TranslateService } from '@ngx-translate/core';
import { LoadingService } from '../../services/loading.service';
@Component({
  selector: 'app-menu-list-item',
  templateUrl: './menu-list-item.component.html',
  styleUrls: ['./menu-list-item.component.css']
  // providers: [{ provide: TooltipConfig, useFactory: getAlertConfig }]

})

export class MenuListItemComponent implements OnInit, OnDestroy {

  isShowMenu: boolean = false;
  userName: any;
  @ViewChild('sidenav') sidenav: MatSidenav;
  isExpanded = true;
  showSubmenu: boolean = false;
  isShowing = false;
  showSubSubMenu: boolean = false;
  showServices: boolean = false;
  showSubReservation: boolean = false;
  showItems: boolean = false;
  private _mobileQueryListener: () => void;
  public collapsed = false;
  expanded: boolean;
  // @HostBinding('attr.aria-expanded') ariaExpanded = this.expanded;
  @Input() depth: number;
  mobileQuery: MediaQueryList;

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  constructor(public navService: NavService,
    public menuService: MenuService,
    public authService: AuthService,
    private loadingService: LoadingService,
    private translate: TranslateService,
    public router: Router, changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    if (this.depth === undefined) {
      this.depth = 0;
    }
  }

  menu: any = [];
  getMenuItems() {
    this.loadingService.showLoading();
    this.menuService.getMenuItems(this.translate.currentLang).subscribe(res => {
      this.loadingService.hideLoading();
      this.menu = res.datalist as NavItem2[];
    })
  }

  ngOnInit() {
    this.menuService.userName = localStorage.getItem("userName");
    this.menuService.imagePath = "assets\\images\\avatar7.png";
    this.getMenuItems();
  }

  selected: boolean;
  toggleSelection(item: NavItem2) {
    item.selected = !item.selected;
  }

  logout() {
    this.authService.logout();
  }
}

export interface NavItem {
  displayName: string;
  disabled?: boolean;
  iconName: string;
  route?: string;
  children?: NavItem[];
}

export interface NavItem2 {
  menuId: number,
  menuKeyName: string,
  menuParentId: number,
  menuUrl: string,
  menuClassName: string,
  menuImagePath: string,
  header: number,
  main: number,
  menuOrder: number,
  inverseMenuParent: any[],
  statusId: any,
  selected: boolean
}
