using BookStore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
    public class ShoppingCart
    {
        private readonly BookStoreDbContext _context;

        private ShoppingCart(BookStoreDbContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service
                .GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = service.GetService<BookStoreDbContext>();
            string cartId = session.GetString("CartId")
                ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public void AddToCart(Book book, int amount)
        {
            var shoppingCartItem = _context.ShoppingCartItems
                .SingleOrDefault(s => s.Book.Id == book.Id
                && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem = _context.ShoppingCartItems
                .SingleOrDefault(s => s.Book.Id == book.Id
                && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Book).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Book.Price * c.Amount).Sum();

            return total;
        }
    }
}
