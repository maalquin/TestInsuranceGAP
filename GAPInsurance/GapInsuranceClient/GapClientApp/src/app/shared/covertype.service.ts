import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CovertypeService {

  constructor(private http:HttpClient) { }

  getCovertTypes(){
    return this.http.get(environment.ApiUrl +'insurance/CoverTypePolicy').toPromise();

  }
}
