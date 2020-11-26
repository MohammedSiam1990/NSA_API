export class MajorServicesModel {
    serviceId: number;
    serviceName: string;
    serviceNameAr: string;
    isActive: number;
    isDefault: boolean;
    creationDate: string;
    foldersPath: string;
    majorServiceTypes: majorServiceTypes;
}

export class majorServiceTypes {
    majorServiceTypeId: number;
    majorServiceId: number;
    typeName: string;
    typeNameAr: string;
    statusId: number;
}

export class MajorServiceTypesModel {
    MajorServiceTypeID: number;
    MajorServiceID: number;
    TypeName: string;
    TypeNameAr: string;
    StatusID: number;
    DeletedBy:string;
    DeletedDate:string;
}