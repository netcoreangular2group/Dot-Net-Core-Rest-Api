using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KPI.Infrastructure;

namespace KPI.Catalog.Domain
{
    public class ProductTemplate : Entity
    {
        [Required]
        public string Name { get; set; }

        public virtual IList<ProductTemplateProductAttribute> ProductAttributes { get; protected set; } = new List<ProductTemplateProductAttribute>();

        public void AddAttribute(long attributeId)
        {
            var productTempateProductAttribute = new ProductTemplateProductAttribute
            {
                ProductTemplate = this,
                ProductAttributeId = attributeId
            };
            ProductAttributes.Add(productTempateProductAttribute);
        }
    }
}
