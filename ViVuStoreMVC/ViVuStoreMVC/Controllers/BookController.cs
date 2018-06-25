using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ViVuStoreMVC.Models;
using ViVuStoreMVC.Repositories;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookController(IBookRepository bookRepository,
            ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Book> books;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                books = _bookRepository.Books.OrderBy(b => b.Id);
                currentCategory = "All books";
            }
            else
            {
                books = _bookRepository.Books
                    .Where(b => b.Category.Name == category)
                    .OrderBy(b => b.Id);

                currentCategory = _categoryRepository.Categories
                    .FirstOrDefault(c => c.Name == category).Name;
            }

            return View(new BooksListViewModel
            {
                Books = books,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(Guid id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}
