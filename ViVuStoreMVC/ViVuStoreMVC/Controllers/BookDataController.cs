using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ViVuStoreMVC.Models;
using ViVuStoreMVC.Repositories;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    public class BookDataController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookDataController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<BookViewModel> LoadMoreBooks()
        {
            IEnumerable<Book> dbBooks = null;
            dbBooks = _bookRepository.GetBooks().OrderBy(b => b.Id).Take(10);

            List<BookViewModel> books = new List<BookViewModel>();

            foreach (var dbBook in dbBooks)
            {
                books.Add(MapDbBookToBookViewModel(dbBook));
            }

            return books;
        }

        private BookViewModel MapDbBookToBookViewModel(Book dbBook)
        {
            return new BookViewModel()
            {
                BookId = dbBook.Id,
                Title = dbBook.Title,
                Price = dbBook.Price,
                Description = dbBook.Description,
                ImageThumbnailUrl = dbBook.ImageThumbnailUrl
            };
        }
    }
}
