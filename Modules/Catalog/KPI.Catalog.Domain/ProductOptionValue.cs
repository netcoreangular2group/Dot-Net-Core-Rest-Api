using KPI.Infrastructure;

namespace KPI.Catalog.Domain
{
    public class ProductOptionValue : Entity
    {
        public long OptionId { get; set; }

        public virtual ProductOption Option { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public string Value { get; set; }
    }
}
