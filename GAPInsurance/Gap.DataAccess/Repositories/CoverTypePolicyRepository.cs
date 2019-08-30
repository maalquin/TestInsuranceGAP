using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess.Repositories
{
    public class CoverTypePolicyRepository : ICoverTypePolicyRepository<GAPCoverTypePolicy>
    {
        public IEnumerable<GAPCoverTypePolicy> GetAll()
        {
            using (var context = new GapContext())
            {
                return  context.GAPCoverTypePolicy
                                    .AsNoTracking()
                                    .ToList();
            }
        }
    }

    public interface ICoverTypePolicyRepository<T>
    {
        IEnumerable<GAPCoverTypePolicy> GetAll();

    }
}
