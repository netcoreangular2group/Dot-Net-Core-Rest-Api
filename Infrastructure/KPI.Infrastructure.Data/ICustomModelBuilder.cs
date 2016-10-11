using Microsoft.EntityFrameworkCore;

namespace KPI.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
