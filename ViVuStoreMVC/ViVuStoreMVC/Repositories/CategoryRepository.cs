using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVuStoreMVC.Data;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ViVuStoreDbContext _context;

        public CategoryRepository(ViVuStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories
        {
            get
            {
                return _context.Categories;
            }
        }
    }
}
