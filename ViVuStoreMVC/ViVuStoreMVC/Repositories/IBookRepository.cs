using System;
using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        IEnumerable<Book> BooksOfTheWeek { get; }
        Book GetBookById(Guid bookId);
    }
}