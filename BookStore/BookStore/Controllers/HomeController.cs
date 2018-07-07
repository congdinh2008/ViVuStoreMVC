using Microsoft.AspNetCore.Mvc;
using BookStore.Repositories;
using BookStore.ViewModels;

namespace BookStore.Controllers
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
                BooksOfTheWeek = _bookRepository.GetBooksOfTheWeek()
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