using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(200)]
        [Display(Name="Tên Nhà Xuất Bản")]
        public string Name { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Thông Tin Nhà Xuất Bản")]
        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}