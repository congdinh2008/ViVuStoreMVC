using BookStore.Data;
using BookStore.Models;
using System;

namespace BookStore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(BookStoreDbContext context,
            ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderedDate = DateTimeOffset.Now;

            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    BookId = shoppingCartItem.Book.Id,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Book.Price
                };

                _context.OrderDetails.Add(orderDetail);
            }

            _context.SaveChanges();
        }
    }
}
