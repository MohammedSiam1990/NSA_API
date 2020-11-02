import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { companyModel } from '../models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { }

  getCompanies(lang: string) {
   return this.http.get<any>("Companies/GetCompanies?Lang=" + lang);
  }

  activeWorkStations(lang: string,model:companyModel) {
    return this.http.post<any>("BranchWorkStations/SaveBranchWorkStations?Lang=" + lang,model);
   }

   deleteWorkStations(TableNme:string,TableKey:string,RowID:number,DeletedBy:string,lang:string) {
    return this.http.post<any>("Operations/DeleteRecord?" +'TableNme='+TableNme+'&'+'TableKey='+TableKey+'&'+'RowID='+RowID+'&'+'DeletedBy='+DeletedBy+'&'+'lang='+lang,null);
   }

}


