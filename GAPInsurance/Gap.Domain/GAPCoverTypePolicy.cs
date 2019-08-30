using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public class GAPCoverTypePolicy : IEntity
    {
        [Key]
        public Guid GAPCoverTypePolicy_Guid { get; set; }
        public string CovertTypeName { get; set; }

        

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
