export class LoginModel {
    userName: string;
    password: string;
    RememberMe: boolean;
    Grant_type: string;
    Refresh_token: string;
}

export class loginTokenModel {
        token: string;
        userName: string;
        email: string;
        userId: string;
        message: string;
        status: string;
        name: string;
        companyId: string;
        companyNameEn: string;
        companyNameAr:string;
        remember_me: boolean;
        success: boolean;
    

}
export class UserInfoViewModel {

    username: string;
    isActiveDirectoryUser: string;
    userProfileUrl: string;
}



