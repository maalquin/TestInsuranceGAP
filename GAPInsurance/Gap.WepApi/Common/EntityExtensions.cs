using Gap.Domain;
using Gap.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gap.WepApi.Common
{
    public static class EntityExtensions
    {
        public static WebApiUserModel ToModel(this GAPWebApiUser user)
        {
            return new WebApiUserModel
            {
                UserName = user.UserName,
                Password = user.Password
              
            };

        }

        public static CoverTypeModel ToModel(this GAPCoverTypePolicy coverTypePolicy)
        {
            return new CoverTypeModel
            {
                Id = coverTypePolicy.GAPCoverTypePolicy_Guid,
                Name = coverTypePolicy.CovertTypeName
            };
        }

        public static TypeRiskModel ToModel(this GAPTypeRisk typeRisk)
        {
            return new TypeRiskModel
            {
                Id = typeRisk.GAPTypeRisk_Guid,
                RiskName = typeRisk.TypeRiskName,
                MaxCovering = String.Format("{0:0.##\\%}", typeRisk.MaxValueCoverRisk)
            };
        }

        public static PolicyModel ToModel(this GAPPolicies policies)
        {
            return new PolicyModel
            {
               PolicyId = policies.Guid,
               AmontMonths = policies.MonthsPolicy,
               TypeRisks = policies.GAPTypeRisk,
               CoverTypePolicy = policies.GAPCoverTypePolicy,
               PolicyIssuer = policies.DatetimePolicyIssuer,
               DateCreated = policies.DatetimeCreated,
               PolicyName = policies.PolicyName,
               FlagDisable = policies.FlagEnable,
               PolicyValue = policies.ValuePolicy.ToString(),
               customerPolicies = policies.GAPCustomerPolicy.ToModel()
               //customerPolicies = policies.GAPCustomerPolicy

            };
        }

        public static CustomerModel ToModel(this GAPCustomerPolicy customerPolicy)
        {
            return new CustomerModel
            {
                Id = customerPolicy.GAPCustomerPolicy_Guid,
                Name = customerPolicy.CustomerName,
                LastName = customerPolicy.CustomerLastName
            };
        }



    }
}