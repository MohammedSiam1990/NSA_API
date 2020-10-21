import { Injectable, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RootSiteMenuViewModel } from '../models/mega-menu-model';


@Injectable({
  providedIn: 'root'
})
export class MenuService {

  obj: RootSiteMenuViewModel;
  child: string;
  parentid: string;
  userName: string;
  imagePath: any;
  @Output() activeItemChanged: EventEmitter<any> = new EventEmitter();

  constructor(private http: HttpClient) { }
  getMenuItems(lang:string) {
    return this.http.get<any>('Menu/GetMenu?Lang='+lang);
  }
}
