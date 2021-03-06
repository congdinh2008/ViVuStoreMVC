﻿using System;
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
        IEnumerable<Book> GetBooksByAuthor(string authorName);
        IEnumerable<Book> GetBooksByPrice(decimal priceLevel);
        IEnumerable<Book> GetBooksByPublisher(string publisherName);
        IEnumerable<Book> GetBooksOfTheWeek();
        void UpdateBook(Book book);
    }
}