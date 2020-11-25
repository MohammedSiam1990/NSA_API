import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-add-service-icon',
  templateUrl: './add-service-icon.component.html',
  styleUrls: ['./add-service-icon.component.css']
})
export class AddServiceIconComponent implements OnInit {

  constructor(public translate: TranslateService) { }

  ngOnInit(): void {
  }

}
