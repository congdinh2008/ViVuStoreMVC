using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Tên Thể Loại")]
        public string Name { get; set; }

        [MaxLength(500)]
        [Display(Name = "Mô Tả")]
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
