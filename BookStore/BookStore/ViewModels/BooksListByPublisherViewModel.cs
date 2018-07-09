using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.ViewModels
{
    public class BooksListByPublisherViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentPublisher { get; set; }
    }
}
