import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BranchWorkStationsModel } from '../models/work-stations-model';

@Injectable({
  providedIn: 'root'
})
export class WorkStationService {

  constructor(private http: HttpClient) { }

  getWorkStations(lang: string) {
   return this.http.get<any>("BranchWorkStations/GetWorkStations?Lang=" + lang);
  }

  activeWorkStations(lang: string,model:BranchWorkStationsModel) {
    return this.http.post<any>("BranchWorkStations/SaveBranchWorkStations?Lang=" + lang,model);
   }

   deleteWorkStations(TableNme:string,TableKey:string,RowID:number,DeletedBy:string,lang:string) {
    return this.http.post<any>("Operations/DeleteRecord?" +'TableNme='+TableNme+'&'+'TableKey='+TableKey+'&'+'RowID='+RowID+'&'+'DeletedBy='+DeletedBy+'&'+'lang='+lang,null);
   }
 
}
