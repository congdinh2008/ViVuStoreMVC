﻿using BookStore.Models;
using BookStore.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
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
