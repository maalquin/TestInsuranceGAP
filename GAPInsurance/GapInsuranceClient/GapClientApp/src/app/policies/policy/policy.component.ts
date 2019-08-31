import { Component, OnInit } from '@angular/core';
import { PolicyService } from 'src/app/shared/policy.service';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PolicyItemsComponent } from '../policy-items/policy-items.component';
import { CustomerService } from 'src/app/shared/customer.service';
import { Customer } from 'src/app/shared/customer.model';



@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: []
})
export class PolicyComponent implements OnInit {
customerList:Customer[];
  constructor(private service:PolicyService,
    private dialog:MatDialog,
    private customerService:CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomerList().then(res => this.customerList = res as Customer[]);
    this.resetForm();
  }

  resetForm(form?:NgForm){
    if (form=null)
      form.resetForm();
    this.service.formData ={
      PolicyId:'',
      CoverTypeId:'',
      RiskTypeId:'',
      CustomerId:'',
      AmontMonths:0,
      PolicyValue:'',
      FlagDisable:false,
      PolicyName:'',
      PolicyIssuer: new Date(),
      PolicyNo:''
    };
    this.service.policyItems = [];
  }

  AddOrEditPolicyItems(PolicyItemIndex, PolicyId){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.data = {PolicyItemIndex, PolicyId};
    this.dialog.open(PolicyItemsComponent,dialogConfig);
  }

}
