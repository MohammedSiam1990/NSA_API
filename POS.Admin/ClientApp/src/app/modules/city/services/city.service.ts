import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CityModel } from '../../district/models/country-model';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient) { }

  getCitiesByCountryId(CountryId: number, lang: string) {
    return this.http.get<any>("City/GetCities/CountryId?CountryId=" + CountryId + '&Lang=' + lang);
  }

  saveCity(lang: string, model: CityModel) {
    return this.http.post<any>("City/SaveCity?Lang=" + lang, model);
  }

  getCityById(cityId: number, lang: string) {
    return this.http.get<any>("City/GetCityById?CityId=" + cityId + '&Lang=' + lang);
  }

  getCities(lang: string) {
    return this.http.get<any>("City/GetCitiesAll?Lang="+lang);
  }


}
