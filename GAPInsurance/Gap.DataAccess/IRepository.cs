using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess
{
    public interface IRepository<T>
    {
        Task<IEnumerable<GAPWebApiUser>> GetAll();
        Task<IEnumerable<GAPWebApiUser>> Query(Expression<Func<T, bool>> predicate);
        T GetByNamePassword(string UserName, string Password);
       

    }
}
