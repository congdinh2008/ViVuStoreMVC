using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ViVuStoreMVC.Models;
using ViVuStoreMVC.Repositories;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IUnitOfWork unitOfWork,
            ShoppingCart shoppingCart)
        {
            _unitOfWork = unitOfWork;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(Guid bookId)
        {
            var selectedBook = _unitOfWork.Books.GetBooks()
                .FirstOrDefault(b => b.Id == bookId);

            if (selectedBook != null)
                _shoppingCart.AddToCart(selectedBook, 1);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(Guid bookId)
        {
            var selectedBook = _unitOfWork.Books.GetBooks()
                .FirstOrDefault(b => b.Id == bookId);

            if (selectedBook != null)
                _shoppingCart.RemoveFromCart(selectedBook);

            return RedirectToAction("Index");
        }
    }
}
