using System.Collections.Generic;
using KPI.Infrastructure;

namespace KPI.Catalog.Domain
{
    public class ProductAttribute : Entity
    {
        public string Name { get; set; }

        public long GroupId { get; set; }

        public virtual ProductAttributeGroup Group { get; set; }

        public virtual IList<ProductTemplateProductAttribute> ProductTemplates { get; protected set; } = new List<ProductTemplateProductAttribute>();
    }
}
