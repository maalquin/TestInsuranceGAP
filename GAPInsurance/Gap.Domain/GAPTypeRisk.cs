using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public class GAPTypeRisk : IEntity
    {
        [Key]
        public Guid GAPTypeRisk_Guid { get; set; }
        public string TypeRiskName { get; set; }
        public double MaxValueCoverRisk { get; set; }


        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
