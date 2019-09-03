import { Typerisk } from './typerisk.model';
import { Covertype } from './covertype.model';
import { Customer } from './customer.model';

export class PolicyItem {

    PolicyId:string;
    CoverTypeId:string;
    RiskTypeId:string;
    CustomerId:string;
    PolicyIssuer:Date;
    AmontMonths:number;
    PolicyValue:string;
    FlagDisable:boolean;
    PolicyName:string;
    PolicyNumber:string;
    //NameRisk:string;
    //NameCover:string;
    TypeRisks:Typerisk;
    CoverTypePolicy: Covertype;
    //customerPolicies: Customer;
    constructor(
        _policyId:string,
        _coverTypeId:string,
        _riskTypeId:string,
        _customerId:string,
        _policyIssuer:Date,
        _amontMonths:number,
        _policyValue:string,
        _flagDisable:boolean,
        _policyName:string,
        _policyNumber:string,
        _typeRisks:Typerisk,
        _coverTypePolicy: Covertype

    ){
        this.PolicyId =  _policyId,
        this.CoverTypeId = _coverTypeId,
        this.RiskTypeId = _riskTypeId,
        this.CustomerId = _customerId,
        this.PolicyIssuer = _policyIssuer,
        this.AmontMonths = _amontMonths,
        this.PolicyValue = _policyValue,
        this.FlagDisable= _flagDisable,
        this.PolicyName = _policyName,
        this.PolicyNumber = _policyNumber,
        this.TypeRisks =  _typeRisks,
        this.CoverTypePolicy = _coverTypePolicy
    }
    
}



