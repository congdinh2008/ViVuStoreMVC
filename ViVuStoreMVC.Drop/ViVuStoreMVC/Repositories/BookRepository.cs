using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ViVuStoreMVC.Data;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ViVuStoreDbContext _context;

        public BookRepository(ViVuStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b=>b.Author)
                .Include(b=>b.Publisher)
                .ToList();
        }

        public IEnumerable<Book> GetBooksOfTheWeek()
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b=>b.IsBookOfTheWeek)
                .ToList();
        }

        public IEnumerable<Book> GetBooksByCategory(string categoryName)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.Category.Name.Contains(categoryName))
                .ToList();
        }
        public IEnumerable<Book> GetBooksByAuthor(string authorName)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.Author.Name.Contains(authorName))
                .ToList();
        }

        public IEnumerable<Book> GetBooksByPublisher(string publisherName)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.Publisher.Name.Contains(publisherName))
                .ToList();
        }
        public Book GetBookById(Guid bookId)
        {
            return _context.Books
                .FirstOrDefault(b => b.Id == bookId);
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
