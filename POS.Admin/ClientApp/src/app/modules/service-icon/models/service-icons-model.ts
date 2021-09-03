export class MajorServicesIconsModel {
    IconID: number
    IconName: string;
    IsActive: boolean;
    OrderID: number;
    ServiceID: number;
    ServiceName: string;
    ServiceNameAr: string;
    FoldersPath: string;
}

export class MajorServicesIconsViewModel {
    iconId: number;
    iconName: string;
    serviceId: number;
    isActive: true;
    orderId: number;
    folderPath:string;
    filePath:File
    Icon:string;
}

export class MajorServicesModel {
    serviceId: number;
    serviceName: string;
    serviceNameAr: string;
    isActive: 1;
    isDefault: string;
    creationDate: string;
    foldersPath: string;
    majorServicesIcons: [];
    majorServiceTypes: []
}