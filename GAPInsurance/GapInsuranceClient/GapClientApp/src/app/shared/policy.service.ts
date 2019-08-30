import { Injectable } from '@angular/core';
import { Policy } from './policy.model';
import { PolicyItem } from './policy-item';


@Injectable({
  providedIn: 'root'
})
export class PolicyService {
formData:Policy;
policyItems: PolicyItem[];

  constructor() { }
}
