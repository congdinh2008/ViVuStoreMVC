using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace BookStore.ViewModels
{
    public class BookEditViewModel
    {
        public Book Book { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public Guid SelectedCategoryId { get; set; }

        public List<SelectListItem> Authors { get; set; }

        public Guid SelectedAuthorId { get; set; }

        public List<SelectListItem> Publishers { get; set; }

        public Guid SelectedPublisherId { get; set; }
    }
}
