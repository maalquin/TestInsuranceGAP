using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.Domain
{
    public enum EntityState
    {
        Added,
        Deleted,
        Detatched,
        Modified,
        Unchanged
    }

    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }
}
