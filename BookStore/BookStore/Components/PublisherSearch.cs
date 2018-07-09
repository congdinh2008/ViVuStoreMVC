using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Components
{
    public class PublisherSearch : ViewComponent
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherSearch(IPublisherRepository publisherRepository)
        {
            this._publisherRepository = publisherRepository;
        }

        public IViewComponentResult Invoke()
        {
            var publishers = _publisherRepository
                .GetPublishers().OrderBy(p => p.Name);
            return View(publishers);
        }
    }
}
