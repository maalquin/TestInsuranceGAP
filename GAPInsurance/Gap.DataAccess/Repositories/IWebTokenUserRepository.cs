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
        IEnumerable<GAPWebAPIUserToken> GetbyGuid(Guid userGuid);
        //Task InsertOrUpdate(T entity);
        bool ExpiredTokenKey(Guid? tokenId);
        Guid InsertOrUpdate(Guid userGuid);
        bool Delete(Guid webUserTokenGuid);
    }
}
