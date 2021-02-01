using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BokDbContext _bokDbContext;
        public CategoryRepository(BokDbContext bokDbContext)
        {
            _bokDbContext = bokDbContext;
        }
        public IEnumerable<Category> AllCategories => _bokDbContext.Categories;
    }
}
