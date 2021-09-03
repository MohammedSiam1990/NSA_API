export class BranchModel {
    BranchID: number;
    BranchNum: string;
    BranchName: string;;
    BranchNameAr: string;
    StatusID: number;
    BrandID: number;
    BrandName: string;
    BrandNameAr: string;
    CreateDateS: string;
    CreateDate: string;
    LastModifyDate: string;
    TaxNo: string;
    ImageName: string;
    Address: string;
    StatusName: string;
    StatusNameAr: string;
    TypeID: number;
    CityName: string;
    CityNameAr: string;
    CompanyName: string;
    CompanyNameAr: string;
    ServiceTypeID: string;
    ApprovedBy: string;
    ApprovedDate: Date;
    WorkStations: WorkStations[] = [];
    DistrictID:string;
}

export class WorkStations {
    BranchWorkstationID: number;
    BranchID: number;
    CompanyID: number;
    WorkstationName: string;
    Serial: string;
    Mac: string;
    StatusID: number;
    CreatedBy: string;
    CreateDate: string;
    CreateDateS: string;
    ApprovedBy: string
    ApprovedDate: string;
    ModifiedBy: string;
    LastModifyDate: string;
    Name: string;
    NameAr: string;
}
