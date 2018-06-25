using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVuStoreMVC.Data;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ViVuStoreDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ViVuStoreDbContext context,
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
