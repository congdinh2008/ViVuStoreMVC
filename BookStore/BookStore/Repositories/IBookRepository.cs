using System;
using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        Book GetBookById(Guid bookId);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetBooksOfTheWeek();
        void UpdateBook(Book book);
    }
}