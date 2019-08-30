using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess.Repositories
{
    public class PoliciesRepository : IPoliciesRepository<GAPPolicies>
    {
        public IEnumerable<GAPPolicies> GetAll()
        {
            using (var context = new GapContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.GAPPolicies
                                    .AsNoTracking()
                                    .Include("GAPTypeRisk")
                                    .Include("GAPCoverTypePolicy")
                                    .Include("GAPCustomerPolicy")
                                    .ToList();
            }
        }
    }

    public interface IPoliciesRepository<T>
    {
        IEnumerable<GAPPolicies> GetAll();
    }
}
