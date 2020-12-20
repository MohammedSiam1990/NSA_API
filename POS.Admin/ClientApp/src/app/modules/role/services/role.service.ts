import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RoleModel } from '../models/role-model';


@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private http: HttpClient) { }

  saveRole(model: RoleModel, lang: string) {
    return this.http.post<any>("Roles/SaveRole?Lang=" + lang, model);
  }

  getRoles(lang: string) {
    return this.http.get<any>("Roles/GetRole?Lang=" + lang);
  }



}
