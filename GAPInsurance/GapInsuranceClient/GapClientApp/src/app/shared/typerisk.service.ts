import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TyperiskService {

  constructor(private Http:HttpClient) { }
  
  getTypeRisk(){
    return this.Http.get(environment.ApiUrl + 'insurance/TypeOfRisk').toPromise();
  }
}
