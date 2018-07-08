using System;
using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IBookReviewRepository
    {
        void AddBookReview(BookReview bookReview);
        IEnumerable<BookReview> GetBookReviewsForBook(Guid bookId);
    }
}