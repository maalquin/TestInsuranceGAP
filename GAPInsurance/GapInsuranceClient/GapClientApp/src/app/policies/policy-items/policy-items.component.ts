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
import { Guid } from "guid-typescript";

@Component({
  selector: 'app-policy-items',
  templateUrl: './policy-items.component.html',
  styleUrls: ['./policy-items.component.css']
})
export class PolicyItemsComponent implements OnInit {
  formData:PolicyItem;
  coverTypeList : Covertype[];
  typeRiskList: Typerisk[];
  isvalid: boolean = true;

  constructor(
   @Inject(MAT_DIALOG_DATA) public data,
   public dialogRef: MatDialogRef<PolicyItemsComponent>,
   private covertypeService:CovertypeService,
   private typeRiskService:TyperiskService,
   private policyService: PolicyService){ }

  ngOnInit() {
    this.covertypeService.getCovertTypes().then(res => this.coverTypeList = res as Covertype[]);
    this.typeRiskService.getTypeRisk().then(res => this.typeRiskList = res as Typerisk[]);
    if(this.data.PolicyItemId == null){
    this.formData ={
      PolicyId: null,
      PolicyNumber: Math.floor(100000 + Math.random()*900000).toString(),
      CoverTypeId: '',
      RiskTypeId: '',
      CustomerId: this.data.customerID,
      PolicyIssuer: this.data.dateIssuer,
      AmontMonths: 0,
      PolicyValue: '',
      FlagDisable: false,
      PolicyName: '',
      TypeRisks: new Typerisk('','','') ,
      CoverTypePolicy : new Covertype('','')

    }
  }
  else{
    this.formData = Object.assign({},this.policyService.policyItems[this.data.PolicyItemId]);
  }

    
  }

  maxValueCover(ctrl){
    debugger;
    if(ctrl.selectedIndex == 0){
      this.formData.TypeRisks.MaxCovering = '0'
    }
    else{
      
      this.formData.TypeRisks.MaxCovering = this.typeRiskList[ctrl.selectedIndex-1].MaxCovering;
      this.formData.TypeRisks.RiskName = this.typeRiskList[ctrl.selectedIndex-1].RiskName;

    }

  }
  nameCoverSet(ctrl){
    if(ctrl.selectedIndex == 0){
      this.formData.TypeRisks.RiskName = ''
    }
    else{
      this.formData.TypeRisks.RiskName = this.coverTypeList[ctrl.selectedIndex-1].Name;
    }

  }
  onSubmit(form:NgForm){
    if(this.validateForm(form.value)){
      var object = form.value;
      var nameRisk = this.typeRiskList.find(x => x.Id == object.TypeRisksId).RiskName;
      var valueCover = this.typeRiskList.find(x => x.Id == object.TypeRisksId).MaxCovering;
      var nameCovering = this.coverTypeList.find(x => x.Id == object.CovertypeId).Name;
  
      var policyItem = new PolicyItem(Guid.createEmpty.toString(),object.cobertTypeId,object.TypeRisksId,object.CustomerId,object.PolicyIssuer,object.AmontMonths,object.PolicyValue,
        false,object.PolicyName,object.PolicyNumber,new Typerisk(object.TypeRisksId,nameRisk,valueCover),new Covertype(object.CovertypeId,nameCovering));
      if(this.data.PolicyItemId == null){
      
     
        this.policyService.policyItems.push(policyItem);
      
      }
      else{

          this.policyService.policyItems[this.data.PolicyItemId] = policyItem;
      }
      this.dialogRef.close();

    }
   
  }
  validateForm(formData: PolicyItem){
    this.isvalid = true;
    if(formData.AmontMonths == 0)
      this.isvalid = false;
    else if(formData.CoverTypeId == '0')
      this.isvalid = false;
    else if (formData.PolicyValue == '0')
      this.isvalid = false;
      return this.isvalid;
  }



}
