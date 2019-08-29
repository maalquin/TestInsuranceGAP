using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public class GAPWebAPIUserToken : IEntity
    {
        public Guid Guid { get; set; }
        public Guid WebAPIUser_Guid { get; set; }
        public Guid TokenId { get; set; }
        public DateTime TokenExpireDateTime { get; set; }
        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
