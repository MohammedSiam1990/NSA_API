import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  constructor(private http: HttpClient) { }

  getBrands(lang: string) {
    return this.http.get<any>("Brand/GetBrands?Lang=" + lang);
  }


}
