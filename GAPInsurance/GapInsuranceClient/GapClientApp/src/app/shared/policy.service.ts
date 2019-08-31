import { Injectable } from '@angular/core';
import { Policy, Policies } from './policy.model';
import { PolicyItem } from './policy-item';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


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
}
