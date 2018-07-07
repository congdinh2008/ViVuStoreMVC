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
            return _context.Books.Include(c => c.Category).ToList();
        }

        public IEnumerable<Book> GetBooksOfTheWeek()
        {
            return _context.Books.Include(c => c.Category)
                .Where(b => b.IsBookOfTheWeek).ToList();
        }

        public Book GetBookById(Guid bookId)
        {
            return _context.Books.FirstOrDefault(b => b.Id == bookId);
        }
    }
}
