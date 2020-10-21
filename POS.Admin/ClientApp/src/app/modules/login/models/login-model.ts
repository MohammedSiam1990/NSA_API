export class AuthenticateModel {
    username: string;
    lang: string;
    password: string;
    RememberMe: boolean;
    userType:number;
    // Grant_type:string;
    // Refresh_token: string;
}
export class VerificationEmailModel {
    email: string;
}

export class RestPasswordModel {
    email: string;
    password: string;
    confirmPassword: string;
    confirmCode: string;
}

export class EmailConfirmedModel {
    email: string;
    confirmCode: string;
}