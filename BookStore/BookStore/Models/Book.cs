using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public int NumberOfPages { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string BookDimensions { get; set; }

        public bool IsBookOfTheWeek { get; set; }

        public int Quantity { get; set; }

        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
