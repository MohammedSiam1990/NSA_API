import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModelAdd } from '../models/user-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUsers(userType: number, lang: string) {
    return this.http.get<any>("Auth/GetUsers?UserType=" + userType + "&Lang=" + lang);

  }

  saveUser(model: UserModelAdd) {
    return this.http.post<any>("Auth/SaveUser", model);
  }

  getUserById(userId: string) {
    return this.http.get<any>("Auth/GetUser/" + userId);
  }




}
