using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ViVuStoreMVC.Repositories;

namespace ViVuStoreMVC.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryMenu(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _unitOfWork.Categories.GetCategories()
                .OrderBy(c => c.Name);

            return View(categories);
        }
    }
}
