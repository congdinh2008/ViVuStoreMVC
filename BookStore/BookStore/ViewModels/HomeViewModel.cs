using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> BooksOfTheWeek { get; set; }
    }
}
