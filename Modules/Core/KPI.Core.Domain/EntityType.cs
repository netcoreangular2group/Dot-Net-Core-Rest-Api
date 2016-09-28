using KPI.Infrastructure;

namespace KPI.Core.Domain
{
    public class EntityType : Entity
    {
        public string Name { get; set; }

        public string RoutingController { get; set; }

        public string RoutingAction { get; set; }
    }
}
