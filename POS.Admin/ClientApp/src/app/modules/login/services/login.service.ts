import { Injectable } from '@angular/core';
import { AuthenticateModel, VerificationEmailModel, RestPasswordModel } from '../models/login-model';
import { HttpClient } from '@angular/common/http';
import { loginTokenModel } from 'src/app/_shared/models/loginModel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public companyId: any;
  public position: any;
  username:string;
  public imagePath:any;
  constructor(private http: HttpClient) { }

  Login(login: AuthenticateModel) {
    return this.http.post<loginTokenModel>('Auth/Login', login);
  }

  reSendVerificationCode(model: VerificationEmailModel) {
    return this.http.post("Account/ReSendVerificationCode", model).pipe();
  }

  forgetPassword(model: RestPasswordModel) {
    return this.http.post("Account/ForgetPassword", model).pipe();
  }

}
