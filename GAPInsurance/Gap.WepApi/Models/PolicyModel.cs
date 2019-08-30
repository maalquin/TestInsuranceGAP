using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gap.WepApi.Models
{
    public class PolicyModel
    {
        public Guid PolicyId { get; set; }
        public Guid? CoverTypeId { get; set; }
        public Guid? RiskTypeId { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime PolicyIssuer { get; set; }
        public int AmontMonths { get; set; }
        public string PolicyValue { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool FlagDisable { get; set; }
        public string PolicyName { get; set; }
        public GAPTypeRisk TypeRisks { get; set; }
        public GAPCoverTypePolicy CoverTypePolicy { get; set; }
        public CustomerModel customerPolicies { get; set; }

    }
}