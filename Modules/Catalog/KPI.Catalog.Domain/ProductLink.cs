﻿using KPI.Infrastructure;

namespace KPI.Catalog.Domain
{
    public class ProductLink : Entity
    {
        public long ProductId { get; set; }

        public Product Product { get; set; }

        public long LinkedProductId { get; set; }

        public Product LinkedProduct { get; set; }

        public ProductLinkType LinkType { get; set; }
    }
}
