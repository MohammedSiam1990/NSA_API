import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ChangePasswordBindingModel } from '../models/changePassword-model';

@Injectable({
  providedIn: 'root'
})
export class ChangePasswordService {

  public showChangePassword:boolean=false;
  constructor(private http: HttpClient) { }

  changePassword(model: ChangePasswordBindingModel) {
    return this.http.post<any>("Auth/ChangePassword", model);
  }
}
