import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyModel } from '../models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { }

  getCompanies(lang: string) {
   return this.http.get<any>("Companies/GetCompanies?Lang=" + lang);
  }

  activeCompany(lang: string,model:CompanyModel) {
    return this.http.post<any>("Companies/UpdateCompany?Lang=" + lang,model);
   }

   deleteCompany(companyId:number,lang:string) {
    return this.http.post<any>("Companies/DeletCompanyeAndUser?CompanyId="+companyId+'&Lang='+lang,null);
   }

}


