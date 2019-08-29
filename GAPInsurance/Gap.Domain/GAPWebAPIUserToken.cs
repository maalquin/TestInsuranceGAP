using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Gap.Domain
{
    public class GAPWebAPIUserToken : IEntity
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid WebAPIUser_Guid { get; set; }
        public Guid TokenId { get; set; }
        public DateTime TokenExpireDateTime { get; set; }
        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
