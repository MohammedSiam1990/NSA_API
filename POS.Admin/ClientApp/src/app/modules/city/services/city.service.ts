import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient) { }

  getCitiesByCountryId(CountryId: number, lang: string) {
    return this.http.get<any>("City/GetCities/CountryId?CountryId=" + CountryId + '&Lang=' + lang);
  }


}
