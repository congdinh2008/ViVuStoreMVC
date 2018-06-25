using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVuStoreMVC.Models;
using ViVuStoreMVC.Repositories;

namespace ViVuStoreMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository,
            ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "Giỏ hàng của bạn hiện trống không ah ^_^, chọn mua vài cuốn nhé!");

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();

                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = HttpContext.User.Identity.Name + ", cảm ơn bạn đã đặt hàng, đơn hàng của bạn sẽ sớm được chuyển tới ^_^";

            return View();
        }
    }
}
