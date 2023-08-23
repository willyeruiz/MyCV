import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GlobalConstants } from 'src/app/common/globalConstants';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlAPI = GlobalConstants.appURL +'/skills';

  constructor(private http: HttpClient) { }

  public getdata(): Observable<any>{
    return this.http.get<any>(this.urlAPI)
  }
}
