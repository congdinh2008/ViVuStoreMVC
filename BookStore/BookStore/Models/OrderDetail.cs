using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }

        [Display(Name = "Số Lượng")]
        public int Amount { get; set; }

        public decimal Price { get; set; }

        public Guid BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}