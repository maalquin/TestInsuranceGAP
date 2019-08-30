using Gap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gap.DataAccess.Repositories
{
    public class TypeRiskRepository : ITypeRiksRepository<GAPTypeRisk>
    {
        public IEnumerable<GAPTypeRisk> GetAll()
        {
            using (var context = new GapContext())
            {
                return context.GAPTypeRisk
                                    .AsNoTracking()
                                    .ToList();
            }
        }
    }

    public interface ITypeRiksRepository<T>
    {
        IEnumerable<GAPTypeRisk> GetAll();
    }
}
