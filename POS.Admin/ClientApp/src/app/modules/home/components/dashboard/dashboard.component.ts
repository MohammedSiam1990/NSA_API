import { Component, OnInit, ViewChild, ElementRef, VERSION, AfterViewInit } from '@angular/core';
import { HomeService } from '../../services/home.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private homeService: HomeService,  public translate: TranslateService) { }

  ngOnInit(): void {
  }

}
