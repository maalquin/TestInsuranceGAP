import { Component, OnInit } from '@angular/core';
import { PolicyService } from 'src/app/shared/policy.service';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PolicyItemsComponent } from '../policy-items/policy-items.component';
import { CustomerService } from 'src/app/shared/customer.service';
import { Customer } from 'src/app/shared/customer.model';
import { PoliciesComponent } from '../policies.component';
import { PolicyItem } from 'src/app/shared/policy-item';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { ToastrService } from 'ngx-toastr';




@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: []
})
export class PolicyComponent implements OnInit {
customerList:Customer[];

  constructor(private service:PolicyService,
    private dialog:MatDialog,
    private customerService:CustomerService,
    private router: Router, 
    private userService: UserService,
    private toastService: ToastrService) { }

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
      PolicyNumber:''
    };
    this.service.policyItems = [];
  }

  AddOrEditPolicyItems(PolicyItemId, PolicyId){
    
    var customerID = this.service.formData.CustomerId;
    var dateIssuer = this.service.formData.PolicyIssuer;
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.data = {customerID,dateIssuer,PolicyItemId };
    this.dialog.open(PolicyItemsComponent,dialogConfig);
  }

  CheckAllPolicies(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    this.dialog.open(PoliciesComponent,dialogConfig);

  }

  onSubmit(){
    var dataInsert = this.service.policyItems;
    
    this.service.insertPolicy(dataInsert).subscribe((data: PolicyItem[]) => 
    {
          console.log(data);
          this.toastService.success("the record has been inserted");
          this.resetForm();

    }, (error: any) => {
      this.toastService.error(error);
      console.log(error)
    }
    );
    

  }


}
