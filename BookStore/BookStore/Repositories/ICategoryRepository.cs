using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}