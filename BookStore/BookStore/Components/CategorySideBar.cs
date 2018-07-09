using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Components
{
    public class CategorySideBar: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategorySideBar(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository
                .GetCategories().OrderBy(c => c.Name);
            return View(categories);
        }
    }
}
