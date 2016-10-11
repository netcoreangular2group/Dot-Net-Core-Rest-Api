using KPI.Infrastructure.Data;
using KPI.Infrastructure;

namespace KPI.Core.Data
{
    public class Repository<T> : RepositoryWithTypedId<T, long>, IRepository<T>
       where T : class, IEntityWithTypedId<long>
    {
        public Repository(KpiDbContext context) : base(context)
        {
        }
    }
}
