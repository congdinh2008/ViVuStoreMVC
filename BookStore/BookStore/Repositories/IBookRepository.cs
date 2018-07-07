using System;
using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        Book GetBookById(Guid bookId);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetBooksOfTheWeek();
    }
}