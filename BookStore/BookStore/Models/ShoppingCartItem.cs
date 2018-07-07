using System;

namespace BookStore.Models
{
    public class ShoppingCartItem
    {
        public string ShoppingCartItemId { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
