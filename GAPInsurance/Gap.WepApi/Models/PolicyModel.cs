﻿using Gap.Domain;
using Newtonsoft.Json;
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
        public DateTime? DateModified { get; set; }
        public bool FlagDisable { get; set; }
        public string PolicyName { get; set; }
        public int PolicyNumber { get; set; }
        public TypeRiskModel TypeRisks { get; set; }
        public CoverTypeModel CoverTypePolicy { get; set; }
        public CustomerModel customerPolicies { get; set; }

    }
}