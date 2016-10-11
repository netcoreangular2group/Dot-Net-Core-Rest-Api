using Microsoft.Extensions.DependencyInjection;

namespace KPI.Infrastructure.Data
{
    public interface IModuleInitializer
    {
        void Init(IServiceCollection serviceCollection);
    }
}
