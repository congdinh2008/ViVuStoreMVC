using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Tên Tác Giả")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Display(Name = "Thông Tin Tác Giả")]
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}