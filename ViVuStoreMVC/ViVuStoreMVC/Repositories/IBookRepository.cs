using System;
using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        Book GetBookById(Guid bookId);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetBooksByAuthor(string authorName);
        IEnumerable<Book> GetBooksByCategory(string categoryName);
        IEnumerable<Book> GetBooksByPublisher(string publisherName);
        IEnumerable<Book> GetBooksOfTheWeek();
    }
}