using BookStore.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Administrators")]
    [Authorize(Policy = "DeleteBook")]
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
            IPublisherRepository publisherRepository)
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
                Categories = categories.Select(c =>
                new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList(),
                SelectedCategoryId = categories.FirstOrDefault().Id,
                Authors = authors.Select(a =>
                new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList(),
                SelectedAuthorId = authors.FirstOrDefault().Id,
                Publishers = publishers.Select(p =>
                new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }).ToList(),
                SelectedPublisherId = publishers.FirstOrDefault().Id,
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
                bookEditViewModel.Book.AuthorId = bookEditViewModel.SelectedAuthorId;
                bookEditViewModel.Book.PublisherId = bookEditViewModel.SelectedPublisherId;
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

            var book = _bookRepository.GetBookById(bookId);

            var bookEditViewModel = new BookEditViewModel
            {
                Categories = categories.Select(c =>
                new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList(),
                Authors = authors.Select(a =>
                new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList(),
                Publishers = publishers.Select(p =>
                new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }).ToList(),
                Book = book,
                SelectedCategoryId = categories.FirstOrDefault().Id,
                SelectedAuthorId = authors.FirstOrDefault().Id,
                SelectedPublisherId = publishers.FirstOrDefault().Id
            };

            return View(bookEditViewModel);
        }

        [HttpPost]
        public IActionResult EditBook(BookEditViewModel bookEditViewModel)
        {
            bookEditViewModel.Book.CategoryId = bookEditViewModel.SelectedCategoryId;
            bookEditViewModel.Book.AuthorId = bookEditViewModel.SelectedAuthorId;
            bookEditViewModel.Book.PublisherId = bookEditViewModel.SelectedPublisherId;

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
