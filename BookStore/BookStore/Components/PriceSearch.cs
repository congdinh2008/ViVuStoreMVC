using BookStore.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Components
{
    public class PriceSearch:ViewComponent
    {
        private readonly IBookRepository _bookRepository;

        public PriceSearch(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IViewComponentResult Invoke(decimal priceLevel)
        {
            var priceSearchItems = new List<PriceSearchItem>
            {
                new PriceSearchItem()
                {
                    DisplayValue = 100000,
                    ActionValue = 100000,

                },
                new PriceSearchItem()
                {
                    DisplayValue = 200000,
                    ActionValue = 200000,

                },
                new PriceSearchItem()
                {
                    DisplayValue = 500000,
                    ActionValue = 500000,

                },
                new PriceSearchItem()
                {
                    DisplayValue = 1000000,
                    ActionValue = 1000000,

                }
            };

            return View(priceSearchItems);
        }
    }

    public class PriceSearchItem
    {
        public decimal DisplayValue { get; set; }
        public decimal ActionValue { get; set; }
    }
}
