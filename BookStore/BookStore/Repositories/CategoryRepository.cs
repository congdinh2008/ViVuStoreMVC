using BookStore.Data;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _context;

        public CategoryRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
