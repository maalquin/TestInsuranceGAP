import { Component, OnInit } from '@angular/core';

import { NgForm } from '@angular/forms';
import { PolicyService } from '../shared/policy.service';
import { Policies } from '../shared/policy.model';


@Component({
  selector: 'app-policies',
  templateUrl: './policies.component.html',
  styleUrls: ['./policies.component.css']
})
export class PoliciesComponent implements OnInit {
  policyList : Policies[];

  constructor(private policyService: PolicyService) { }

  ngOnInit() {
    this.policyService.getAllPolicies().then(res => this.policyList = res as Policies[]);

  }
  EditPolicy(){

  }



}
