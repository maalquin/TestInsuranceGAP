using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess.Repositories
{

    public class CustomerRepository : ICustomerRepository<GAPCustomerPolicy>
    {
        public IEnumerable<GAPCustomerPolicy> GetAll()
        {
            using (var context = new GapContext())
            {
                return context.GAPCustomerPolicy
                                    .AsNoTracking()
                                    .ToList();
            }
        }

    }
    public interface ICustomerRepository<T>
    {
        IEnumerable<GAPCustomerPolicy> GetAll();
    }



}
