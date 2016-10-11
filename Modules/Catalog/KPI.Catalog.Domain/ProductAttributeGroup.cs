using System.Collections.Generic;
using KPI.Infrastructure;

namespace KPI.Catalog.Domain
{
    public class ProductAttributeGroup : Entity
    {
        public string Name { get; set; }

        public virtual IList<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}
