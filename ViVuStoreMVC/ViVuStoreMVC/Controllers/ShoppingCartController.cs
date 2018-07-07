using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViVuStoreMVC.Models;
using ViVuStoreMVC.Repositories;
using ViVuStoreMVC.ViewModels;

namespace ViVuStoreMVC.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IBookRepository bookRepository,
            ShoppingCart shoppingCart)
        {
            _bookRepository = bookRepository;
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
            var selectedBook = _bookRepository.GetBooks()
                .FirstOrDefault(b => b.Id == bookId);

            if (selectedBook != null)
                _shoppingCart.AddToCart(selectedBook, 1);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(Guid bookId)
        {
            var selectedBook = _bookRepository.GetBooks()
                .FirstOrDefault(b => b.Id == bookId);

            if (selectedBook != null)
                _shoppingCart.RemoveFromCart(selectedBook);

            return RedirectToAction("Index");
        }
    }
}
