using System.Collections.Generic;
using BookStore.Models;

namespace BookStore.Repositories
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers();
    }
}