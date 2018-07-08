using BookStore.Data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repositories
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly BookStoreDbContext _context;

        public BookReviewRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public void AddBookReview(BookReview bookReview)
        {
            _context.BookReviews.Add(bookReview);
            _context.SaveChanges();
        }

        public IEnumerable<BookReview> GetBookReviewsForBook(Guid bookId)
        {
            return _context.BookReviews.Where(b => b.Book.Id == bookId).ToList();
        }
    }
}
