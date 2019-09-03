using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gap.WepApi.Models
{
    public class PolicyRequestModel
    {
        public Guid PolicyId { get; set; }
        public Guid? RiskTypeId { get; set; }
        public Guid CustomerId { get;set; }
        public DateTime? PolicyIssuer { get; set; }
        public int AmontMonths { get; set; }
        public int PolicyValue { get; set; }
        public bool FlagDisable { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyName { get; set; }
        public TypeRiskModel TypeRisks { get; set; }
        public CoverTypeModel CoverTypePolicy { get; set; }

    }
}