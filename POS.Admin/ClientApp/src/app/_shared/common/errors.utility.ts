import { HttpErrorResponse } from "@angular/common/http";

export class errorsUtility {
 
    public static getBusinessException(err: HttpErrorResponse): businessExceptionModel {
        var businessException = new businessExceptionModel();
        if (err.status === 400) {
            // err.error.forEach(x => {
            //     businessException.message = x.Message;
            //     businessException.type = x.BusinessExceptionType;
            // });
              businessException.message =  err.error.message ;
            //   businessException.emailConfirmedStatus =  err.error.emailConfirmedStatus ;
                // businessException.type = x.BusinessExceptionType;
            return businessException; 
        }
        throw err;
    }
}

export class businessExceptionModel {
    public message: string;
    // public type: businessExceptionTypesModel;
    // public emailConfirmedStatus:any;
}

export enum businessExceptionTypesModel {
    default = 0,
    loginFailedAsEmailNotConfirmed = 1,
}