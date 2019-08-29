using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public class GAPCustomerPolicy : IEntity
    {
        [Key]
        public Guid Guid { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public virtual ICollection<GAPPolicies> Policies { get; set; } = new List<GAPPolicies>();

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
