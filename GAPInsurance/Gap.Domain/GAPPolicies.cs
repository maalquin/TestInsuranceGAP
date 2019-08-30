using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public class GAPPolicies : IEntity
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid GAPCoverTypePolicy_Guid { get; set; }
        public Guid GAPTypeRisk_Guid { get; set; }
        public Guid? GAPCustomerPolicy_Guid { get; set; }
        public DateTime DatetimePolicyIssuer { get; set; }
        public int MonthsPolicy { get; set; }
        public Decimal? ValuePolicy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeModified { get; set; }
        public bool FlagEnable { get; set; }
        public string PolicyName { get; set; }

        
        public virtual GAPTypeRisk GAPTypeRisk { get; set; }
        public virtual GAPCustomerPolicy GAPCustomerPolicy { get; set; }
        public virtual GAPCoverTypePolicy GAPCoverTypePolicy { get; set; }


        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
