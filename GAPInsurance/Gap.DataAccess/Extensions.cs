using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess
{
    public static class Extensions
    {
        public static System.Data.Entity.EntityState ToEntityFrameworkState(this EntityState entityState)
        {
            switch (entityState)
            {
                case EntityState.Added:
                    return System.Data.Entity.EntityState.Added;
                case EntityState.Deleted:
                    return System.Data.Entity.EntityState.Deleted;
                case EntityState.Detached:
                    return System.Data.Entity.EntityState.Detached;
                case EntityState.Modified:
                    return System.Data.Entity.EntityState.Modified;
                case EntityState.Unchanged:
                    return System.Data.Entity.EntityState.Unchanged;
                default:
                    return System.Data.Entity.EntityState.Added;
            }
        }
    }
}
