using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.ViewModels
{
    public class PriceSearchViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public decimal PriceLevel { get; set; }
    }
}
