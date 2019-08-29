using Gap.Domain;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess
{

    public class WebApiUserRepository : IRepository<GAPWebApiUser>
    {
        public async Task<IEnumerable<GAPWebApiUser>> GetAll()
        {
            using (var context = new GapContext())
            {
                return await context.GAPWebAPIUsers
                                    .AsNoTracking()
                                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<GAPWebApiUser>> Query(Expression<Func<GAPWebApiUser, bool>> predicate)
        {
            using (var context = new GapContext())
            {
                return await context.GAPWebAPIUsers
                                    .AsNoTracking()
                                    .Where(predicate)
                                    .ToListAsync();
            }
        }

        public async Task<GAPWebApiUser> GetByNamePassword(string UserName, string Password)
        {
            using (var context = new GapContext())
            {
                return await context.GAPWebAPIUsers
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.UserName == UserName && x.Password == Password);
            }
        }
    }
}
