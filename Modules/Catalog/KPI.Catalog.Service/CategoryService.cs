using KPI.Catalog.Domain;
using KPI.Core.Data;
using KPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPI.Catalog.Service
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetCategory(long id)
        {
            return _categoryRepository.Query().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Category pro)
        {
            throw new NotImplementedException();
        }

        public void Update(Category pro)
        {
            throw new NotImplementedException();
        }

    }
}
