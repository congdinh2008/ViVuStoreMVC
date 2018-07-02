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

        public IEnumerable<Book> GetBooksByCategory(Guid categoryId)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.CategoryId == categoryId)
                .ToList();
        }
        public IEnumerable<Book> GetBooksByAuthor(Guid authorId)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.AuthorId == authorId)
                .ToList();
        }

        public IEnumerable<Book> GetBooksByPublisher(Guid publisherId)
        {
            return _context.Books
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Where(b => b.PublisherId == publisherId)
                .ToList();
        }
        public Book GetBookById(Guid bookId)
        {
            return _context.Books
                .Include(b=>b.Category)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefault(b => b.Id == bookId);
        }
    }
}
