import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from '@progress/kendo-angular-l10n';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { RoleModel } from '../../models/role-model';
import { RoleService } from '../../services/role.service';

@Component({
  selector: 'app-edit-role',
  templateUrl: './edit-role.component.html',
  styleUrls: ['./edit-role.component.css']
})
export class EditRoleComponent implements OnInit {

  roleId: number;
  form: FormGroup;
  model: RoleModel;
  public validationMessages = {
    nameAr_required: this.translate.instant('field_is_Required'),
    name_required: this.translate.instant('field_is_Required')
  };

  constructor(public translate: TranslateService, private fb: FormBuilder, private router: Router, private loadingService: LoadingService,
    private route: ActivatedRoute,
    private messages: MessageService, private notificationService: NotificationService, private roleService: RoleService) {
    this.roleId = this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.model = new RoleModel();
    this.createForm();
    this.getRoleById();
  }

  createForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      nameAr: ['', Validators.required]
    })
  }


  getRoleById() {
    this.roleService.getRoleById(this.translate.currentLang, this.roleId).subscribe(data => {
      debugger
      this.model = data.datalist;
      this.form = this.fb.group({
        name: [this.model.name, Validators.required],
        nameAr: [this.model.nameAr, Validators.required]

      })
    })
  }

  userId: any;
  saveRole() {
    this.model = this.form.value;
    this.userId = localStorage.getItem("userId");
    this.model.modifiedBy = this.userId;
    this.model.id=this.roleId;
    this.roleService.saveRole(this.model, this.translate.currentLang).subscribe(data => {
      if (data.success) {
        this.notificationService.showNotification(data.message, NotificationType.Success);
        this.router.navigate(['/role/list']);
      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error);
      }
    })

  }


}
