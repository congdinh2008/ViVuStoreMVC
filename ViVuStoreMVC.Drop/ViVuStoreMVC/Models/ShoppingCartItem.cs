using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViVuStoreMVC.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public Guid Id { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }

        public Book Book { get; set; }
    }
}
