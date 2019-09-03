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
        public async Task InsertOrUpdate(GAPPolicies policies)
        {
            using (var context = new GapContext())
            {
                context.Entry(policies).State = policies.EntityState.ToEntityFrameworkState();
               // context.Entry(policies.GAPCustomerPolicy).State = policies.GAPCustomerPolicy.EntityState.ToEntityFrameworkState();
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IPoliciesRepository<T>
    {
        IEnumerable<GAPPolicies> GetAll();
        Task InsertOrUpdate(GAPPolicies policies);
    }
}
