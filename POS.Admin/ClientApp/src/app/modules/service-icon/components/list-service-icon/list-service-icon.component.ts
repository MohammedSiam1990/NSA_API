import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { PageSizeItem } from '@progress/kendo-angular-grid';
import { MessageService } from '@progress/kendo-angular-l10n';
import { GroupDescriptor, DataResult, process, SortDescriptor } from '@progress/kendo-data-query';
import { LoadingService } from 'src/app/_shared/services/loading.service';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { IconService } from '../../services/icon.service';
import { environment } from 'src/environments/environment';
import { MajorServicesIconsModel, MajorServicesIconsViewModel, MajorServicesModel } from '../../models/service-icons-model';
import { DomSanitizer } from '@angular/platform-browser';
import { NotificationType } from 'src/app/_shared/components/notification/notification.component';
import { NotificationService } from 'src/app/_shared/services/notification.service';
import { DeleteServiceIconComponent } from '../delete-service-icon/delete-service-icon.component';

@Component({
  selector: 'app-list-service-icon',
  templateUrl: './list-service-icon.component.html',
  styleUrls: ['./list-service-icon.component.css']
})
export class ListServiceIconComponent implements OnInit {

  pathIconApi: string = environment.ImgUrl;
  @ViewChild("deleteServiceIconCom") deleteServiceIconCom: DeleteServiceIconComponent;
  model: any;;
  showEdit: boolean = false;

  constructor(private iconService: IconService, private loadingService: LoadingService,
    public _d: DomSanitizer,
    private ref: ChangeDetectorRef,
    private notificationService: NotificationService,
    public translate: TranslateService) {
  }

  public ngOnInit(): void {
    this.getMajorServices();
  }


  WorkStations: any;
  MajorServicesIcons: any = [];
  serviceId: number;
  getMajorServicesIcons(): void {
    this.iconService.getMajorServicesIcons(this.translate.currentLang, this.serviceId).subscribe(res => {
      this.MajorServicesIcons = res.datalist;
      this.MajorServicesIcons.forEach(element => {
        element.IconName = element.IconName + '?' + Date.now();
      });
    })

  }

  MajorServicesArr: any = [];
  getMajorServices() {
    this.iconService.getMajorServices(this.translate.currentLang).subscribe(res => {
      this.MajorServicesArr = res.datalist as MajorServicesModel;
    })
  }

  folderPath: string;
  onChangeMajorService(item: MajorServicesModel) {
    this.serviceId = item.serviceId;
    this.folderPath = item.foldersPath;
    this.getMajorServicesIcons();
  }

  uploadData = new FormData();
  profileImgFileToUpload: File = null;
  profileImgFileNameToUpload: string = null;
  imageUrl: any = "assets\\images\\disable.jpg";
  onFileChange(event) {
    this.uploadData = new FormData()
    if (event.target.files.length === 0) {
      this.imageUrl = "assets\\images\\disable.jpg";
      return;
    }
    this.profileImgFileToUpload = event.target.files[0];
    var reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);
    reader.onload = (_event) => {
      this.imageUrl = reader.result;
      this.profileImgFileNameToUpload = this.profileImgFileToUpload.name
    }
    const file = event.srcElement.files[0];
    this.imageUrl = window.URL.createObjectURL(file);
    this.uploadData.append('File', event.target.files[0]);

  }

  addMajorServicesIcons() {
    if (!this.profileImgFileToUpload || !this.serviceId) {
      this.notificationService.showNotification("Please Compleate Data", NotificationType.Alert)
      return;
    }
    var model = new MajorServicesIconsViewModel();
    model.serviceId = this.serviceId;
    model.filePath = this.profileImgFileToUpload;
    model.folderPath = this.folderPath;
    model.iconName = "this.imageUrl";
    model.isActive = true;
    model.iconId = 0
    this.iconService.addMajorServicesIcons(this.translate.currentLang, model).subscribe(data => {
      if (data.success) {
        this.getMajorServicesIcons();
        this.notificationService.showNotification(data.message, NotificationType.Success)

      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    });
  }

  updateServiceIcon() {
    var model = new MajorServicesIconsViewModel();
    model.serviceId = this.model.ServiceID;
    model.filePath = this.profileImgFileToUpload;
    model.folderPath = this.model.FoldersPath;
    model.iconName = this.model.IconName;
    model.isActive = true;
    model.Icon = this.model.Icon
    model.iconId = this.model.IconID

    this.iconService.editMajorServicesIcons(this.translate.currentLang, model).subscribe(data => {
      if (data.success) {

        this.getMajorServicesIcons();
        setTimeout(this.imageUrl, 1000);
        this.notificationService.showNotification(data.message, NotificationType.Success)

      } else {
        this.notificationService.showNotification(data.message, NotificationType.Error)
      }
    });
  }

  showDeleteServiceIcon(item: MajorServicesIconsModel) {
    this.deleteServiceIconCom.show(item);
  }

  disabled: boolean = false;
  showUpdateServiceIcon(item) {
    this.showEdit = true;
    this.imageUrl = this.pathIconApi + item.IconName;
    this.model = item as MajorServicesIconsViewModel;
  }

  saveServiceIcon() {
    if (this.model.IconID > 0)
      this.updateServiceIcon();
    else
      this.addMajorServicesIcons();
  }

  showNewServiceIcon() {
    this.showEdit = false;
    this.imageUrl = "assets\\images\\disable.jpg";
  }

}
