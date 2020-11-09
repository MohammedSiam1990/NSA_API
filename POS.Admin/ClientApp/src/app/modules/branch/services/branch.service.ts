import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BranchModel } from '../models/branch-model';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  constructor(private http: HttpClient) { }

  getBranches(lang:string) {
    return this.http.get<any>("Branch/GetBranches?Lang="+lang)
  }

  activeBranch(lang: string,model:BranchModel) {
    return this.http.post<any>("Branch/Save_Branches?Lang=" + lang,model);
   }

   deleteBranch(TableNme:string,TableKey:string,RowID:number,DeletedBy:string,lang:string) {
    return this.http.post<any>("Operations/DeleteRecord?" +'TableNme='+TableNme+'&'+'TableKey='+TableKey+'&'+'RowID='+RowID+'&'+'DeletedBy='+DeletedBy+'&'+'lang='+lang,null);
   }

}
