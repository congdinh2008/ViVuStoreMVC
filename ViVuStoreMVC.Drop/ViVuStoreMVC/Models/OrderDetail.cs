using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStoreMVC.Models
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        
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