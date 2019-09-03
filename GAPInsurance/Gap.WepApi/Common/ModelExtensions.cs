using Gap.Domain;
using Gap.WepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gap.WepApi.Common
{
    public static class ModelExtensions
    {
        public static GAPPolicies ToEntity(this PolicyRequestModel policyModel)
        {
            var entity = new GAPPolicies
            {
                Guid = policyModel.PolicyId.IsEmpty() ? Guid.NewGuid() : policyModel.PolicyId,
                PolicyName = policyModel.PolicyName,
                FlagEnable = policyModel.FlagDisable,
                DatetimeModified = DateTime.Now,
                DatetimeCreated = policyModel.PolicyId == null ? DateTime.Now : DateTime.Now,
                ValuePolicy = Convert.ToDecimal(policyModel.PolicyValue),
                MonthsPolicy = policyModel.AmontMonths,
                EntityState = (policyModel.PolicyId == null || policyModel.PolicyId.IsEmpty()) ? EntityState.Added : EntityState.Modified,
                PolicyNumber = Convert.ToInt32(policyModel.PolicyNumber),
                DatetimePolicyIssuer = policyModel.PolicyIssuer.Value,
                GAPCustomerPolicy_Guid = policyModel.CustomerId,
                GAPCoverTypePolicy_Guid = policyModel.CoverTypePolicy.Id,
                GAPTypeRisk_Guid = policyModel.TypeRisks.Id
                
            };

            return entity;
        }
        public static GAPPolicies ToEntity(this PolicyModel policyModel)
        {
            var entity = new GAPPolicies
            {
                Guid = policyModel.PolicyId.IsEmpty() ? Guid.NewGuid() : policyModel.PolicyId,
                PolicyName = policyModel.PolicyName,
                FlagEnable = policyModel.FlagDisable,
                DatetimeModified = DateTime.Now,
                DatetimeCreated = policyModel.PolicyId == null ? DateTime.Now : policyModel.DateCreated,
                ValuePolicy = Convert.ToDecimal(policyModel.PolicyValue),
                MonthsPolicy = policyModel.AmontMonths,
                EntityState = policyModel.PolicyId == null ? EntityState.Added : EntityState.Modified,
                GAPCustomerPolicy = policyModel.customerPolicies.ToEntity(),
                PolicyNumber = policyModel.PolicyNumber,
                DatetimePolicyIssuer = policyModel.PolicyIssuer,
                GAPCustomerPolicy_Guid = policyModel.CustomerId,
                GAPCoverTypePolicy_Guid = policyModel.CoverTypeId.Value,

            };

            return entity;
        }

        public static GAPCustomerPolicy ToEntity(this CustomerModel customerModel)
        {
            var entity = new GAPCustomerPolicy
            {
                GAPCustomerPolicy_Guid = customerModel.Id.IsEmpty() ? Guid.NewGuid() : customerModel.Id,
                CustomerLastName = customerModel.LastName,
                CustomerName = customerModel.Name,
                EntityState = customerModel.Id.IsEmpty() ? EntityState.Added : EntityState.Modified
            };
            return entity;
        }

        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }
    }
}