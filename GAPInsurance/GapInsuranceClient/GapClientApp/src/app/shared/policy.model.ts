import { BrowserDynamicTestingModule } from '@angular/platform-browser-dynamic/testing';
import { Typerisk } from './typerisk.model';
import { Covertype } from './covertype.model';
import { Customer } from './customer.model';

export class Policy {
    PolicyId:string;
    CoverTypeId:string;
    RiskTypeId:string;
    CustomerId:string;
    PolicyIssuer:Date;
    AmontMonths:number;
    PolicyValue:string;
    FlagDisable:boolean;
    PolicyName:string;
    PolicyNo:string;

}

export class Policies {
    PolicyId:string;
    CoverTypeId:string;
    RiskTypeId:string;
    CustomerId:string;
    PolicyIssuer:Date;
    AmontMonths:number;
    PolicyValue:string;
    FlagDisable:boolean;
    PolicyName:string;
    PolicyNo:string;
    DateCreated: Date;
    DateModified: Date;
    TypeRisks: Typerisk;
    CoverTypePolicy: Covertype;
    customerPolicies: Customer;

}

