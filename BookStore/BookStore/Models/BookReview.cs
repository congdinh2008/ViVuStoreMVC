using System;

namespace BookStore.Models
{
    public class BookReview
    {
        public Guid BookReviewId { get; set; }
        public Book Book { get; set; }
        public string Review { get; set; }
    }
}
