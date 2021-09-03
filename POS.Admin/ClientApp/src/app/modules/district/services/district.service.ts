import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DistrictModel } from '../models/country-model';

@Injectable({
  providedIn: 'root'
})
export class DistrictService {

  constructor(private http: HttpClient) { }

  getDistricts(lang: string) {
    return this.http.get<any>("District/GetDistricts?Lang=" + lang);
  }

  getCountries(lang: string) {
    return this.http.get<any>("City/GetCountries?Lang=" + lang);
  }
0
  getCitiesByCountryId(countryId: number, lang: string) {
    return this.http.get<any>("City/GetCities/CountryId?CountryId=" + countryId + '&Lang=' + lang);
  }

  addDistract(lang: string, model: DistrictModel) {
    return this.http.post<any>("District/AddDistract?Lang=" + lang, model);
  }

  updateDistrict(lang: string, model: DistrictModel) {
    return this.http.post<any>("District/UpdateDistrict?Lang=" + lang, model);
  }

  getDistrictById(districtId: number, lang: string) {
    return this.http.get<any>("District/GetDistrict?DistrictId=" + districtId + '&Lang=' + lang);
  }

  getDistrictsByCityId(CityId: number, lang: string) {
    return this.http.get<any>("District/GetDistrictsByCity?CityId=" + CityId + '&Lang=' + lang);
  }

}
