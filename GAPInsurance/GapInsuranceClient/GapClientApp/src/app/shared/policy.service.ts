import { Injectable } from '@angular/core';
import { Policy, Policies } from './policy.model';
import { PolicyItem } from './policy-item';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {_throw} from 'rxjs/observable/throw';
import {map, catchError} from 'rxjs/operators';
import {Observable, throwError} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PolicyService {
formData:Policy;
policyItems: PolicyItem[];
policies: Policies[];

  constructor(private Http:HttpClient) { 

  }

  getAllPolicies(){
    return this.Http.get(environment.ApiUrl + 'insurance/GetPolicies').toPromise();
  }

  insertPolicy(formData : PolicyItem[]): Observable<PolicyItem[]>{
    
    return this.Http.post<PolicyItem[]>(environment.ApiUrl + 'insurance/InsertUpdate', formData, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    })
    .pipe(catchError(e => throwError(e)))
  }
}
