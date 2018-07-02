using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ViVuStoreMVC.Models;
using ViVuStoreMVC.Repositories;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Book> books;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                books = _unitOfWork.Books.GetBooks().OrderBy(b => b.Title);
                currentCategory = "All books";
            }
            else
            {
                books = _unitOfWork.Books.GetBooks()
                    .Where(b => b.Category.Name == category)
                    .OrderBy(b => b.Title);

                currentCategory = _unitOfWork.Categories.GetCategories()
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
            var book = _unitOfWork.Books.GetBookById(id);
            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}
