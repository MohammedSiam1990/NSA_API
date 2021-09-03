import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { majorServiceTypes } from '../models/major-service-model';

@Injectable({
  providedIn: 'root'
})
export class MajorServiceService {

  constructor(private http: HttpClient) { }

  getMajorServices(lang: string) {
    return this.http.get<any>("MajorServices/GetMajorServices?Lang=" + lang);
  }

  saveMajorServiceTypes(lang: string, model: majorServiceTypes[]) {
    return this.http.post<any>("MajorServiceTypes/SaveMajorServiceTypes?Lang=" + lang, model);
  }

  getMajorServiceTypesByMajorServiceId(majorServiceId: number, lang: string) {
    return this.http.get<any>("MajorServiceTypes/GetMajorServiceTypesById?MajorServiceId=" + majorServiceId + '&Lang=' + lang);
  }

  deleteServiceTypes(TableNme:string,TableKey:string,RowID:number,DeletedBy:string,lang:string) {
    return this.http.post<any>("Operations/DeleteRecord?" +'TableNme='+TableNme+'&'+'TableKey='+TableKey+'&'+'RowID='+RowID+'&'+'DeletedBy='+DeletedBy+'&'+'lang='+lang,null);
   }

}
