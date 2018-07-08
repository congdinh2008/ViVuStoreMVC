using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.ViewModels
{
    public class BookEditViewModel
    {
        public Book Book { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public Guid AuthorId { get; set; }
        public IEnumerable<SelectListItem> Authors { get; set; }
        public Guid PublisherId { get; set; }
        public IEnumerable<SelectListItem> Publishers { get; set; }
    }
}
