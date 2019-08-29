using Gap.DataAccess.Repositories;
using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess
{
    public class WebUserTokenRepository : IWebTokenUserRepository<GAPWebAPIUserToken>
    {
     

        public async Task<IEnumerable<GAPWebAPIUserToken>> GetbyGuid(Guid userGuid)
        {
            using (var context = new GapContext())
            {
                return await context.GAPWebAPIUserTokens
                                    .AsNoTracking().Where(x => x.WebAPIUser_Guid == userGuid)
                                    .ToListAsync();
            }
        }

       
    }
}
