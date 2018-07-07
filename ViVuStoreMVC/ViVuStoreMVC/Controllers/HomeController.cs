using Microsoft.AspNetCore.Mvc;
using ViVuStoreMVC.Repositories;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                BooksOfTheWeek = _bookRepository.BooksOfTheWeek
            };

            return View(homeViewModel);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}