import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }

  getbyId() {
    return this.http.get("Auth/GetUser/00d74c08-34b5-425a-8201-7c748be7cea7");
  }
}
