using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public class GAPCoverTypePolicy : IEntity
    {
        public Guid Guid { get; set; }
        public string CovertTyeName { get; set; }

        public virtual ICollection<GAPCoverTypePolicy> CoverTypePolicies { get; set; } = new List<GAPCoverTypePolicy>();

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
