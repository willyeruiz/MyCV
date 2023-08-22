import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlAPI = 'https://localhost:7033/api/Experiences';

  constructor(private http: HttpClient) {}

  public getdata(): Observable<any>{
    return this.http.get<any>(this.urlAPI)
  }
}
