import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
// import { loginTokenModel } from 'src/app/account/models/loginModel';
// import { LoginService } from 'src/app/account/services/login.service';
// import { PushNotificationService } from '../push-notification.service';
import { loginTokenModel } from '../../models/loginModel';
import { LoadingService } from '../loading.service';



@Injectable({
    providedIn: 'root'
})
export class AuthService {
    AuthorizationUserKEY = 'AuthorizationUser';
    AuthorizationUserKEYExternal = 'AuthorizationUserExternal';
    AuthorizationUserTempKEY = 'AuthorizationUserTempClient';
    LogoutUserKEY = 'LogoutUser';
    isRememberMeKEY = 'RememberMeClient';
    SelectedLanguageKEY = 'SelectedLanguage';

    constructor(public router: Router,
        private loadingService: LoadingService,
        private translate: TranslateService,
        // private loginService: LoginService,
        // private pushNotificationService: PushNotificationService
    ) {
    }

    public isAuthenticated(): boolean {

        const tokenObj = this.getAuthorizationTokenObject();
        if (tokenObj == null)
            return false;
        return true;
    }

    setAuthorizationToken(loginToken: loginTokenModel, rememberMe: boolean) {
        localStorage.setItem("companyId", loginToken.companyId);
        localStorage.setItem("companyNameEn", loginToken.companyNameEn);
        localStorage.setItem("userId", loginToken.userId);
        localStorage.setItem("userName", loginToken.userName);
        localStorage.removeItem(this.LogoutUserKEY);
        if (rememberMe) {
            localStorage.setItem(this.isRememberMeKEY, "True");
            localStorage.setItem(this.AuthorizationUserKEY, JSON.stringify(loginToken));
        }
        else {
            localStorage.setItem(this.AuthorizationUserTempKEY, JSON.stringify(loginToken));
            // var x=loginToken.access_token
            // localStorage.setItem('Token', 'bearer '+x);
            sessionStorage.setItem(this.AuthorizationUserKEY, JSON.stringify(loginToken));
        }
        // this.pushNotificationService.onOpenSignalR.emit();
    }

    logout() {
        this.logoutWithoutRedirect();
        this.router.navigate(['/login']);
    }

    logoutWithoutRedirect() {
        localStorage.removeItem(this.AuthorizationUserKEY);
        localStorage.removeItem(this.AuthorizationUserTempKEY);
        sessionStorage.removeItem(this.AuthorizationUserKEY);
        // this.loginService.removeCurrentUserModel();
        localStorage.setItem(this.LogoutUserKEY, "LoggedOut");
        //  this.pushNotificationService.onCloseSignalR.emit();
    }

    getAuthorizationToken(): string {
        if (this.getAuthorizationTokenObject() != null)
            return this.getAuthorizationTokenObject().token;
        return "";
    }

    getAuthorizationTokenType(): string {
        if (this.getAuthorizationTokenObject() != null)
            return this.getAuthorizationTokenObject().token;
        return "";
    }

    getAuthorizationRefreshToken(): string {
        if (this.getAuthorizationTokenObject() != null)
            // return this.getAuthorizationTokenObject().refresh_token;
            return "";
    }

    getAuthorizationRoles(): string[] {
        if (this.getAuthorizationTokenObject() != null)
            // return this.getAuthorizationTokenObject().role;
            return [];
    }

    getAuthorizationName(): string {
        if (this.getAuthorizationTokenObject() != null)
            // return this.getAuthorizationTokenObject().name;
            return "";
    }

    setCurrentLanguage(language) {
        localStorage.setItem(this.SelectedLanguageKEY, language);
        if (language == "en") {

            this.removeArabicStyle();
            this.setEnglishLanguageStyle();

        } else {
            this.removeEnglishStyle();
            this.setArabicLanguageStyle();


        }
    }

    getCurrentLanguage() {
        var selectedLanguage = localStorage[this.SelectedLanguageKEY];
        if (selectedLanguage == undefined)
            return "en"
        return selectedLanguage;
    }

    setArabicLanguageStyle() {
        this.removeEnglishStyle();
        this.loadCSS("arabic-style-a", "assets/theme/css/bootstrap.min.rtl.css");
        this.loadCSS("arabic-style-b", "assets/theme/css/Ar-StyleSheet.css");
        this.loadCSS("arabic-style-d", "assets/theme/css/valadtion-ar.css");
        this.loadCSS("arabic-style-c", "assets/theme/css/main-Ar.css");
    }

    setEnglishLanguageStyle() {
        this.removeArabicStyle();
        this.loadCSS("english-style-a", "assets/theme/css/bootstrap.min.css");
        this.loadCSS("english-style-b", "assets/theme/css/e-StyleSheet.css");
        this.loadCSS("english-style-d", "assets/theme/css/valadtion.css");
        this.loadCSS("english-style-c", "assets/theme/css/main.css");
    }

    removeArabicStyle() {
        if (document.getElementById("arabic-style-a"))
            document.getElementById("arabic-style-a").remove();
        if (document.getElementById("arabic-style-b"))
            document.getElementById("arabic-style-b").remove();
        if (document.getElementById("arabic-style-c"))
            document.getElementById("arabic-style-c").remove();
        if (document.getElementById("arabic-style-d"))
            document.getElementById("arabic-style-d").remove();
        if (document.getElementById("ar"))
            document.getElementById("ar").remove();
        if (document.getElementById("ar"))
            document.getElementById("ar").remove();
    }

    removeEnglishStyle() {
        if (document.getElementById("english-style-a"))
            document.getElementById("english-style-a").remove();
        if (document.getElementById("english-style-b"))
            document.getElementById("english-style-b").remove();
        if (document.getElementById("english-style-c"))
            document.getElementById("english-style-c").remove();
        if (document.getElementById("english-style-d"))
            document.getElementById("english-style-d").remove();
    }

    loadCSS(cssId, url) {
        if (!document.getElementById(cssId)) {
            var head = document.getElementsByTagName('head')[0];
            var link = document.createElement('link');
            link.id = cssId;
            link.rel = 'stylesheet';
            link.type = 'text/css';
            link.href = url;
            link.media = 'all';
            head.appendChild(link);
        }
    }

    private getAuthorizationTokenObject(): loginTokenModel {
        try {
            if (localStorage.length > 0) {

                var isLoggedOut = localStorage[this.LogoutUserKEY];
                if (isLoggedOut == "LoggedOut")
                    return null;

                var objLocal = localStorage[this.AuthorizationUserKEY];
                if (objLocal != null)
                    return JSON.parse(objLocal) as loginTokenModel;
                else {
                    objLocal = localStorage[this.AuthorizationUserKEYExternal];
                    if (objLocal != null)
                        return JSON.parse(objLocal) as loginTokenModel;
                }
            }
            if (sessionStorage.length > 0) {
                var objSession = sessionStorage[this.AuthorizationUserKEY];
                if (objSession != null)
                    return JSON.parse(objSession) as loginTokenModel;
            }

            // var objLocal = this.local.get(this.AuthorizationUserKEY);
            // if (objLocal == null) {
            //     var localStorage = this.local as any;
            //     if (localStorage.storage && localStorage.storage.length > 0) {
            //         var tempObjLocal = localStorage.storage.AuthorizationUserExternal;
            //         objLocal = JSON.parse(tempObjLocal);
            //     }
            // }
            // //var objLocal = this.local.get(this.AuthorizationUserKEY);
            // if (objLocal != null)
            //     return objLocal as loginTokenModel;

            // var objSession = this.session.get(this.AuthorizationUserKEY);
            // if (objSession != null)
            //     return objSession as loginTokenModel;

            return null;
        }
        catch
        {
            return null;
        }
    }
}
