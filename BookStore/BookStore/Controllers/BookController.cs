using BookStore.Models;
using BookStore.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly HtmlEncoder _htmlEncoder;

        public BookController(
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository,
            IBookReviewRepository bookReviewRepository,
            HtmlEncoder htmlEncoder)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _bookReviewRepository = bookReviewRepository;
            _htmlEncoder = htmlEncoder;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Book> books;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                books = _bookRepository.GetBooks().OrderBy(b => b.Title);
                currentCategory = "Tất Cả Sách";
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

        public IActionResult ListByPrice(decimal priceLevel)
        {
            IEnumerable<Book> books;
            decimal currentPrice = decimal.Zero;

            if (priceLevel<0)
            {
                books = _bookRepository.GetBooks().OrderBy(b => b.Title);
                currentPrice = 0;
            }
            else
            {
                books = _bookRepository.GetBooksByPrice(priceLevel)
                    .OrderBy(b => b.Title);

                currentPrice = priceLevel;
            }

            return View(new BooksListByPriceViewModel
            {
                Books = books,
                CurrentPrice = currentPrice
            });
        }

        public IActionResult ListByAuthor(string authorName)
        {
            IEnumerable<Book> books;
            string currentAuthor = string.Empty;

            if (string.IsNullOrEmpty(authorName))
            {
                books = _bookRepository.GetBooks().OrderBy(b => b.Title);
                currentAuthor = "Tất Cả Tác Giả";
            }
            else
            {
                books = _bookRepository.GetBooksByAuthor(authorName)
                    .OrderBy(b => b.Title);

                currentAuthor = authorName;
            }

            return View(new BooksListByAuthorViewModel
            {
                Books = books,
                CurrentAuthor = currentAuthor
            });
        }

        public IActionResult ListByPublisher(string publisherName)
        {
            IEnumerable<Book> books;
            string currentPublisher = string.Empty;

            if (string.IsNullOrEmpty(publisherName))
            {
                books = _bookRepository.GetBooks().OrderBy(b => b.Title);
                currentPublisher = "Tất Cả Các Nhà Xuất Bản";
            }
            else
            {
                books = _bookRepository.GetBooksByPublisher(publisherName)
                    .OrderBy(b => b.Title);

                currentPublisher = publisherName;
            }

            return View(new BooksListByPublisherViewModel
            {
                Books = books,
                CurrentPublisher = currentPublisher
            });
        }

        public IActionResult Details(Guid id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            book.BookReviews = _bookReviewRepository.GetBookReviewsForBook(id).ToList();
            return View(new BookDetailViewModel()
            {
                Book = book,
            });
        }

        [HttpPost]
        public IActionResult Details(Guid id, string review)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            string encodeReview = _htmlEncoder.Encode(review);

            _bookReviewRepository.AddBookReview(
                new BookReview()
                {
                    Book = book,
                    Review = encodeReview
                });

            var bookDetailViewModel = new BookDetailViewModel()
            {
                Book = book
            };

            return RedirectToAction("Details");
        }
    }
}
