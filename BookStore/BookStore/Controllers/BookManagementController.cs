using BookStore.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    public class BookManagementController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookManagementController(
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetBooks().OrderBy(b => b.Title);

            return View(books);
        }

        public IActionResult AddBook()
        {
            var categories = _categoryRepository.GetCategories();
            var bookEditViewModel = new BookEditViewModel
            {
                Categories = categories.Select(c =>
                new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList(),
                SelectedCategoryId = categories.FirstOrDefault().Id,
            };
            return View(bookEditViewModel);
        }

        [HttpPost]
        public IActionResult AddBook(BookEditViewModel bookEditViewModel)
        {
            //Basic validation
            if (ModelState.IsValid)
            {
                bookEditViewModel.Book.CategoryId = bookEditViewModel.SelectedCategoryId;
                _bookRepository.AddBook(bookEditViewModel.Book);
                return RedirectToAction("Index");
            }
            return View(bookEditViewModel);
        }

        public IActionResult EditBook(Guid bookId)
        {
            var categories = _categoryRepository.GetCategories();

            var book = _bookRepository.GetBookById(bookId);

            var bookEditViewModel = new BookEditViewModel
            {
                Categories = categories.Select(c =>
                new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList(),
                Book = book,
                SelectedCategoryId = book.CategoryId
            };

            return View(bookEditViewModel);
        }

        [HttpPost]
        public IActionResult EditBook(BookEditViewModel bookEditViewModel)
        {
            bookEditViewModel.Book.CategoryId = bookEditViewModel.SelectedCategoryId;

            if (!ModelState.IsValid)
            {
                return View(bookEditViewModel);
            }

            _bookRepository.UpdateBook(bookEditViewModel.Book);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteBook(Guid bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            _bookRepository.DeleteBook(book);

            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckIfBookTitleAlreadyExists([Bind(Prefix = "Book.Title")]string title)
        {
            var book = _bookRepository.GetBooks().FirstOrDefault(b => b.Title == title);
            return book == null ? Json(true) : Json("Tựa sách này đã có sẵn");
        }
    }
}
