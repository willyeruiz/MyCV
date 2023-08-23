import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GlobalConstants } from 'src/app/common/globalConstants';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlAPI = GlobalConstants.appURL +'/studies';

  constructor(private http: HttpClient) { }

  public getdata(): Observable<any>{
    var s = this.http.get<any>(this.urlAPI)
    return s;
  }
}
