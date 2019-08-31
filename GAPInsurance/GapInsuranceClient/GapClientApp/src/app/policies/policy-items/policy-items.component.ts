import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA,MatDialogRef } from '@angular/material';
import { inject } from '@angular/core/testing';
import { Policy } from 'src/app/shared/policy.model';
import { PolicyItem } from 'src/app/shared/policy-item';
import { CovertypeService } from 'src/app/shared/covertype.service';
import { Covertype } from 'src/app/shared/covertype.model';
import { TyperiskService } from 'src/app/shared/typerisk.service';
import { Typerisk } from 'src/app/shared/typerisk.model';
import { PolicyService } from 'src/app/shared/policy.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-policy-items',
  templateUrl: './policy-items.component.html',
  styleUrls: ['./policy-items.component.css']
})
export class PolicyItemsComponent implements OnInit {
  formData:PolicyItem;
  coverTypeList : Covertype[];
  typeRiskList: Typerisk[];

  constructor(
   @Inject(MAT_DIALOG_DATA) public data,
   public dialogRef: MatDialogRef<PolicyItemsComponent>,
   private covertypeService:CovertypeService,
   private typeRiskService:TyperiskService,
   private policyService: PolicyService){ }

  ngOnInit() {
    this.covertypeService.getCovertTypes().then(res => this.coverTypeList = res as Covertype[]);
    this.typeRiskService.getTypeRisk().then(res => this.typeRiskList = res as Typerisk[]);
    this.formData ={  
      PoliciyItemID: null,
      PolicyId: this.data.PolicyId,
      PolicyNo: Math.floor(100000 + Math.random()*90000).toString(),
      CoverTypeId: '',
      RiskTypeId: '',
      CustomerId: '',
      PolicyIssuer: new Date(),
      AmontMonths: 0,
      PolicyValue: '',
      FlagDisable: false,
      PolicyName: '',
      MaxCoverPolicy:'',
      NameRisk:'',
      NameCover:''

    }
  }

  maxValueCover(ctrl){
    if(ctrl.selectedIndex == 0){
      this.formData.MaxCoverPolicy = '0'
    }
    else{
      this.formData.MaxCoverPolicy = this.typeRiskList[ctrl.selectedIndex-1].MaxCovering;
      this.formData.NameRisk = this.typeRiskList[ctrl.selectedIndex-1].RiskName;

    }

  }
  nameCoverSet(ctrl){
    if(ctrl.selectedIndex == 0){
      this.formData.NameCover = ''
    }
    else{
      this.formData.NameCover = this.coverTypeList[ctrl.selectedIndex-1].Name;
    }

  }
  onSubmit(form:NgForm){
    this.policyService.policyItems.push(form.value);
    this.dialogRef.close();
  }



}
