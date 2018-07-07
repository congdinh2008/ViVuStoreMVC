using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStoreMVC.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}