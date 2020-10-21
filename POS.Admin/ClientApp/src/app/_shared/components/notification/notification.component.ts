import { Component, OnInit, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css'],

})
export class NotificationComponent implements OnInit {

  MyType = NotificationType;
  Type: NotificationType;
  Message: string = "";

  showNotification: boolean = false;
  animateIn: boolean = false;
  animateOut: boolean = false;
  @Input() notificationExtraclass: string = "";

  constructor(private toastr: ToastrService) { }

  ngOnInit() {

  }

  show(message: string, type: NotificationType) {
   
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

    // this.Message = message;
    // this.Type = type;
    // this.showNotification = true;
    // this.animateIn = true;
    // setTimeout(() => { this.showNotification = false; }, 4000);
  }

  hide() {
    //this.showNotification = false;
    this.toastr.clear();
  }
}


export enum NotificationType {
  Success,
  Error,
  Alert
}