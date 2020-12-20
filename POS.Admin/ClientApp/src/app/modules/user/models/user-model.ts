export class userModel {
    CompanyId: number;
    CreateDate: string;
    CreateDateS: string;
    Email: string;
    Id: string;
    InsertedBy: string;
    IsSuperAdmin: boolean
    Name: string;
    PhoneNumber: number;
    StatusID: number;
    StatusName: string;
    StatusNameAr: string;
    UserName: string;
    UserType: number;
}

export class UserModelAdd {
    id: string;
    email: string;
    username: string;
    phoneNumber: string;
    lang: string;
    name: string;
    userType: number;
    insertedBy: string;
    modifiedBy: string;
    lastModifyDate: string;
    companyId: number;
    isSuperAdmin: boolean;
    statusID: number;
    appUrl: string;

}