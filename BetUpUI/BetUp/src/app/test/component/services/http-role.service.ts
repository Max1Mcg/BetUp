import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpRoleService {

  constructor(private http: HttpClient) { }

  testApi(){
    this.http.get("https://localhost:7124/Odds/test");
  }
}
