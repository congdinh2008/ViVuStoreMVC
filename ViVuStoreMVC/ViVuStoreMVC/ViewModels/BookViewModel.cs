using System;

namespace ViVuStoreMVC.ViewModels
{
    public class BookViewModel
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}
