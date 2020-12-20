import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from '@progress/kendo-angular-l10n';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService, NotificationType } from 'src/app/_shared/services/notification.service';
import { UserModelAdd } from '../../models/user-model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  userId: string;
  form: FormGroup;
  userModelAdd: UserModelAdd;
  public validationMessages = {
    username_required: this.translate.instant('field_is_Required'),
    name_required: this.translate.instant('field_is_Required'),
    phoneNumber_required: this.translate.instant('field_is_Required'),
    username_pattern: this.translate.instant('username_not_valid')
  };

  constructor(public translate: TranslateService, private fb: FormBuilder, private router: Router, private loadingService: LoadingService,
    private route: ActivatedRoute,
    private messages: MessageService, private notificationService: NotificationService, private userService: UserService) {
    this.userId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.userModelAdd = new UserModelAdd();
    this.createForm();
    this.getUserById();


  }

  createForm() {
    this.form = this.fb.group({
      username: [{ value: '', disabled: true }, [Validators.required, Validators.pattern('^([a-zA-Z0-9_.+-]+)@([a-zA-Z0-9-]+[\.][a-zA-Z0-9-.]{1,})$')]],
      name: ['', Validators.required],
      phoneNumber: [null, Validators.required],
      statusID: [null],
      isSuperAdmin: [false]
    })
  }

  getUserById() {
    this.userService.getUserById(this.userId).subscribe(data => {
      this.userModelAdd = data;
      this.form = this.fb.group({
        username: [ this.userModelAdd.email, Validators.required],
        name: [this.userModelAdd.name, Validators.required],
        phoneNumber: [this.userModelAdd.phoneNumber, Validators.required],
        statusID: [null],
        isSuperAdmin: [this.userModelAdd.isSuperAdmin]
    
      })
      if (this.userModelAdd.statusID == 7)
      this.form.controls.statusID.setValue(true);
      else
      this.form.controls.statusID.setValue(false);
      this.userId = this.userModelAdd.id;
    })

  }

  saveUser() {
    this.userModelAdd.username = this.form.value.username;
    this.userModelAdd.name = this.form.value.name;
    this.userModelAdd.phoneNumber = this.form.value.phoneNumber;
    this.userModelAdd.isSuperAdmin = this.form.value.isSuperAdmin;
    this.userModelAdd.email = this.form.value.username;
    this.userModelAdd.lang = this.translate.currentLang;
    this.userModelAdd.id = this.userId;
    this.userModelAdd.userType = 2;
    if (this.form.value.statusID)
      this.userModelAdd.statusID = 7;
    else
      this.userModelAdd.statusID = 8;
    this.userService.saveUser(this.userModelAdd).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success);
        this.router.navigate(['/user/list']);
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error);
      }
    })
  }

}
