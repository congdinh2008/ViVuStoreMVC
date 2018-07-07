using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
