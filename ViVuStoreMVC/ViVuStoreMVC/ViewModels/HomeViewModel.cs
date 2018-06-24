using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> BooksOfTheWeek { get; set; }
    }
}
