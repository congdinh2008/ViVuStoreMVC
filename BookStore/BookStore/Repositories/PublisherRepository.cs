using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreDbContext _context;

        public PublisherRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }
    }
}
