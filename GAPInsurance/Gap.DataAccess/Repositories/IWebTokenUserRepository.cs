using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess.Repositories
{
    public interface IWebTokenUserRepository<T>
    {
        Task<IEnumerable<GAPWebAPIUserToken>> GetbyGuid(Guid userGuid);
    }
}
