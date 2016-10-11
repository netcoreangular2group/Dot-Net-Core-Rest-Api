using KPI.Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPI.Catalog.Service
{
    public interface ICategoryService
    {
        Category GetCategory(long id);

        void Insert(Category pro);

        void Update(Category pro);

    }
}
