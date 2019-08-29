using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public class GAPWebApiUser : IEntity
    {
        [Key]
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<GAPWebApiUser> GAPWebApiUsers { get; set; } = new List<GAPWebApiUser>();

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
