import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {MajorServicesIconsViewModel } from '../models/service-icons-model';

@Injectable({
  providedIn: 'root'
})
export class IconService {

  constructor(private http: HttpClient) { }

  getMajorServicesIcons(lang: string, ServiceId: number) {
    return this.http.get<any>("MajorServicesIcons/GetMajorServicesByIcons?ServiceId=" + ServiceId + '&' + 'Lang=' + lang);
  }

  getMajorServices(lang: string) {
    return this.http.get<any>("MajorServices/GetMajorServices?Lang=" + lang);
  }


  addMajorServicesIcons(lang: string, model: MajorServicesIconsViewModel) {
    const formData = new FormData();
    for (const prop in model) {
      if (!model.hasOwnProperty(prop)) { continue; }
      formData.append(prop, model[prop]);
    }
    return this.http.post<any>("MajorServicesIcons/AddMajorServicesIcons?Lang=" + lang, formData);
  }

  editMajorServicesIcons(lang: string, model: MajorServicesIconsViewModel) {
    const formData = new FormData();
    for (const prop in model) {
      if (!model.hasOwnProperty(prop)) { continue; }
      formData.append(prop, model[prop]);
    }
    return this.http.post<any>("MajorServicesIcons/UpdateMajorServicesIcons?Lang=" + lang, formData);
  }

  deleteMajorServicesIcons(MajorServicesIconsId: number) {
    return this.http.post<any>("MajorServicesIcons/DeleteMajorServicesIcons?MajorServicesIconsId=" + MajorServicesIconsId, null);
  }

}
