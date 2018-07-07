using BookStore.Models;
using BookStore.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
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
                books = _bookRepository.GetBooks().OrderBy(b => b.Title);
                currentCategory = "All books";
            }
            else
            {
                books = _bookRepository.GetBooks()
                    .Where(b => b.Category.Name == category)
                    .OrderBy(b => b.Title);

                currentCategory = _categoryRepository.GetCategories()
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
