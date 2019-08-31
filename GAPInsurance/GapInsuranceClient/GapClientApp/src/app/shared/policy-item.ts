import { Typerisk } from './typerisk.model';
import { Covertype } from './covertype.model';
import { Customer } from './customer.model';

export class PolicyItem {

    PoliciyItemID: string;
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
    MaxCoverPolicy:string;
    NameRisk:string;
    NameCover:string;
   // TypeRisks:Typerisk;
    //CoverTypePolicy: Covertype;
    //customerPolicies: Customer;
}
