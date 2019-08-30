import { Component, OnInit } from '@angular/core';
import { PolicyService } from 'src/app/shared/policy.service';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PolicyItemsComponent } from '../policy-items/policy-items.component';
import {MatDatepickerModule} from '@angular/material/datepicker';


@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: []
})
export class PolicyComponent implements OnInit {

  constructor(private service:PolicyService,
    private dialog:MatDialog,
    private calendar:MatDatepickerModule ) { }

  ngOnInit() {
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
      PolicyNo:Math.floor(100000 + Math.random()*90000).toString()
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
