using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using ViVuStoreMVC.Repositories;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    public class BookManagementController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookManagementController(
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository,
            IAuthorRepository authorRepository,
            IPublisherRepository publisherRepository
            )
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }
        public IActionResult Index()
        {
            var books = _bookRepository.GetBooks().OrderBy(b => b.Title);
            return View(books);
        }

        public IActionResult AddBook()
        {
            var categories = _categoryRepository.GetCategories();
            var authors = _authorRepository.GetAuthors();
            var publishers = _publisherRepository.GetPublishers();

            var bookEditViewModel = new BookEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem()
                { Value = c.Id.ToString(), Text = c.Name }).ToList(),
                CategoryId = categories.FirstOrDefault().Id,
                Authors = authors.Select(a => new SelectListItem()
                { Value = a.Id.ToString(), Text = a.Name }).ToList(),
                AuthorId = authors.FirstOrDefault().Id,
                Publishers = publishers.Select(p => new SelectListItem()
                { Value = p.Id.ToString(), Text = p.Name }).ToList(),
                PublisherId = publishers.FirstOrDefault().Id
            };

            return View(bookEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(BookEditViewModel bookEditViewModel)
        {
            if (ModelState.IsValid)
            {
                bookEditViewModel.Book.CategoryId = bookEditViewModel.CategoryId;
                bookEditViewModel.Book.AuthorId = bookEditViewModel.AuthorId;
                bookEditViewModel.Book.PublisherId = bookEditViewModel.PublisherId;

                _bookRepository.AddBook(bookEditViewModel.Book);
                return RedirectToAction("Index");
            }

            return View(bookEditViewModel);
        }

        public IActionResult EditBook(Guid bookId)
        {
            var categories = _categoryRepository.GetCategories();
            var authors = _authorRepository.GetAuthors();
            var publishers = _publisherRepository.GetPublishers();

            var book = _bookRepository.GetBooks().FirstOrDefault(b
                => b.Id == bookId);

            var bookEditViewModel = new BookEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem()
                { Text = c.Name, Value = c.Id.ToString() }).ToList(),
                Authors = authors.Select(a => new SelectListItem()
                { Text = a.Name, Value = a.Id.ToString() }).ToList(),
                Publishers = publishers.Select(p => new SelectListItem()
                { Text = p.Name, Value = p.Id.ToString() }).ToList(),
                Book = book,
                CategoryId = book.CategoryId,
                AuthorId = book.AuthorId,
                PublisherId = book.PublisherId,
            };

            var item = bookEditViewModel.Categories.FirstOrDefault(c
                => c.Value == book.CategoryId.ToString());
            item.Selected = true;

            var item2 = bookEditViewModel.Authors.FirstOrDefault(a
                => a.Value == book.AuthorId.ToString());
            item2.Selected = true;

            var item3 = bookEditViewModel.Publishers.FirstOrDefault(p
                => p.Value == book.PublisherId.ToString());
            item3.Selected = true;

            return View(bookEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBook(BookEditViewModel bookEditViewModel)
        {
            bookEditViewModel.Book.CategoryId = bookEditViewModel.CategoryId;
            bookEditViewModel.Book.AuthorId = bookEditViewModel.AuthorId;
            bookEditViewModel.Book.PublisherId = bookEditViewModel.PublisherId;

            if (ModelState.IsValid)
            {
                _bookRepository.UpdateBook(bookEditViewModel.Book);
                return RedirectToAction("Index");
            }

            return View(bookEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteBook(Guid bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            _bookRepository.DeleteBook(book);

            return RedirectToAction("Index");
        }
    }
}
