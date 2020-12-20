import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from '@progress/kendo-angular-l10n';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { UserModelAdd } from '../../models/user-model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  form: FormGroup;
  userModelAdd: UserModelAdd;
  public validationMessages = {
    username_required: this.translate.instant('field_is_Required'),
    name_required: this.translate.instant('field_is_Required'),
    phoneNumber_required: this.translate.instant('field_is_Required'),
    username_pattern: this.translate.instant('username_not_valid')
  };

  constructor(public translate: TranslateService, private fb: FormBuilder, private router: Router, private loadingService: LoadingService,
    private messages: MessageService, private notificationService: NotificationService, private userService: UserService) { }

  ngOnInit(): void {
    this.userModelAdd = new UserModelAdd();
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      username: ['', [Validators.required, Validators.pattern('^([a-zA-Z0-9_.+-]+)@([a-zA-Z0-9-]+[\.][a-zA-Z0-9-.]{1,})$')]],
      name: ['', Validators.required],
      phoneNumber: [null, Validators.required],
      statusID: [null],
      isSuperAdmin: [false]
    })
  }

  saveUser() {
    this.userModelAdd = this.form.value;
    this.userModelAdd.email = this.form.value.username;
    this.userModelAdd.lang = this.translate.currentLang;
    this.userModelAdd.id = null;
    if (this.form.value.statusID)
      this.userModelAdd.statusID = 7;
    else
      this.userModelAdd.statusID = 8;
    this.userModelAdd.userType = 2;
    this.userService.saveUser(this.userModelAdd).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success);
        this.form.reset();
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error);
      }
    })

  }

}
