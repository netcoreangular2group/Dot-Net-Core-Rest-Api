using KPI.Infrastructure;
using KPI.Core.Domain;

namespace KPI.Catalog.Domain
{
    public class ProductMedia : Entity
    {
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        public long MediaId { get; set; }

        public virtual Media Media { get; set; }

        public int DisplayOrder { get; set; }
    }
}
