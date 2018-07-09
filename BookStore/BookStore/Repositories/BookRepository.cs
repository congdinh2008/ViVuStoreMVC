using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books
                .Include(c => c.Category)
                .Include(a=>a.Author)
                .Include(p=> p.Publisher)
                .ToList();
        }

        public IEnumerable<Book> GetBooksOfTheWeek()
        {
            return _context.Books
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .Where(b => b.IsBookOfTheWeek)
                .ToList();
        }

        public Book GetBookById(Guid bookId)
        {
            return _context.Books
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetBooksByPrice(decimal priceLevel)
        {
            return _context.Books
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .Where(b => b.Price < priceLevel).ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            return _context.Books
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .Where(b => b.Author.Name.Contains(authorName)).ToList();
        }

        public IEnumerable<Book> GetBooksByPublisher(string publisherName)
        {
            return _context.Books
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.Publisher)
                .Where(b => b.Publisher.Name.Contains(publisherName)).ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
