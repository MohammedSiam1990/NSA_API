export class CountryModel {
    countryId: number;
    countryName: string;
    countryNameAr: string;
    currencyId: number;
    code: string;
    flag: string;
    currencyName: string;
    currencyNameAr: string;
}

export class CityModel {
    cityId: number;
    cityName: string;
    cityNameAr: string;
    countryId: number;
    countryName: string;
    countryNameAr: string;
}

export class DistrictModel {
    districtId: number;
    districtName: string
    districtNameAr: string
    cityId: number;
    inActive: boolean;
    cityName: string
    cityNameAr: string;
    countryId:number;
}
