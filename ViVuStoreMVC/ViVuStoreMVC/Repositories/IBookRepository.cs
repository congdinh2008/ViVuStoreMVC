using System;
using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public interface IBookRepository
    {
        Book GetBookById(Guid bookId);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetBooksByAuthor(Guid authorId);
        IEnumerable<Book> GetBooksByCategory(Guid categoryId);
        IEnumerable<Book> GetBooksByPublisher(Guid publisherId);
        IEnumerable<Book> GetBooksOfTheWeek();
    }
}