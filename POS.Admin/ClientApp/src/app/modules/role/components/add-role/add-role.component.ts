import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from '@progress/kendo-angular-l10n';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { RoleModel } from '../../models/role-model';
import { RoleService } from '../../services/role.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
  styleUrls: ['./add-role.component.css']
})
export class AddRoleComponent implements OnInit {

  form: FormGroup;
  model: RoleModel;
  public validationMessages = {
    nameAr_required: this.translate.instant('field_is_Required'),
    name_required: this.translate.instant('field_is_Required')
  };

  constructor(public translate: TranslateService, private fb: FormBuilder, private router: Router, private loadingService: LoadingService,
    private messages: MessageService, private notificationService: NotificationService, private roleService: RoleService) { }

  ngOnInit(): void {
    this.model = new RoleModel();
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      nameAr: ['', Validators.required]
    })
  }

  userId: any;
  saveRole() {
    this.model = this.form.value;
    this.userId = localStorage.getItem("userId");
    this.model.insertedBy = this.userId;
    this.roleService.saveRole(this.model, this.translate.currentLang).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success);
        this.form.reset();
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error);
      }
    })

  }


}
