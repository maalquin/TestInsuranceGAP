using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gap.WepApi.Models
{
    public class TypeRiskModel
    {
        public Guid Id { get; set; }
        public string RiskName { get; set; }
        public string MaxCovering { get; set; }
    }
}