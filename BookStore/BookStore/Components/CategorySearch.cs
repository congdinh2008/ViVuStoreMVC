﻿using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Components
{
    public class CategorySearch: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategorySearch(ICategoryRepository categoryRepository)
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