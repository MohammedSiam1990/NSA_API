import { EventEmitter, Injectable } from '@angular/core';
import { Event, NavigationEnd, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavService {
  public collapsed = false;
  public appDrawer: any;
  public currentUrl = new BehaviorSubject<string>(undefined);
  public isExpanded: boolean = true;
  isShowMenu:boolean=false;
  constructor(private router: Router) {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) {
        this.currentUrl.next(event.urlAfterRedirects);
      }
    });
  }

  isOpen: boolean = false;
  public closeNav() {
    this.appDrawer.close();
    this.isOpen = true;
  }

  public openNav() {
    this.appDrawer.open();
    this.isOpen = false;
  }

  public openNavC() {
    if (this.isOpen)
      this.openNav();
    else
      this.closeNav();
  }
}