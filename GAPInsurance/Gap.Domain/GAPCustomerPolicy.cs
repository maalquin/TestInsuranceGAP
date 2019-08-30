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
        public Guid GAPCustomerPolicy_Guid { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
       

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
