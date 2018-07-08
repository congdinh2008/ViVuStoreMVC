using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentCategory { get; set; }
    }
}
