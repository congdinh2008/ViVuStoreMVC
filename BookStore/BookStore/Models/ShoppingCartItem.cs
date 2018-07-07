using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public string ShoppingCartItemId { get; set; }

        public Book Book { get; set; }

        [Display(Name = "Số Lượng")]
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
