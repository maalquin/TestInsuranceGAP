export class Typerisk {
    Id :string;
    RiskName:string;
    MaxCovering:string;
    constructor(
        _id:string,
        _riskName:string,
        _maxCovering:string

    ){
        this.Id = _id;
        this.RiskName = _riskName;
        this.MaxCovering = _maxCovering;
    }
 
}

