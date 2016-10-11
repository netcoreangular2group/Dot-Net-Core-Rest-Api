﻿using KPI.Infrastructure;

namespace KPI.Core.Domain
{
    public class District : Entity
    {
        public long StateOrProvinceId { get; set; }

        public virtual StateOrProvince StateOrProvince { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Location { get; set; }
    }
}
