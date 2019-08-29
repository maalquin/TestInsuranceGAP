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
        public Guid CoverTypeGuid { get; set; }
        public Guid TypeRiskGuid { get; set; }
        public Guid CustomerGuid { get; set; }
        public DateTime DatetimePolicyIssuer { get; set; }
        public int MonthsPolicy { get; set; }
        public int ValuePolicy { get; set; }
        public DateTime DatetimeCreated { get; set; }
        public DateTime DatetimeModified { get; set; }
        public bool FlagEnable { get; set; }

        public virtual ICollection<GAPPolicies> Policies { get; set; } = new List<GAPPolicies>();

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
