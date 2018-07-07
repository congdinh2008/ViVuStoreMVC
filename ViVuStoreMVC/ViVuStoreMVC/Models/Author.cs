using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStoreMVC.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}