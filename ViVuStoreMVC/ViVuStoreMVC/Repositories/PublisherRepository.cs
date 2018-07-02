using System.Collections.Generic;
using System.Linq;
using ViVuStoreMVC.Data;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ViVuStoreDbContext _context;

        public PublisherRepository(ViVuStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }
    }
}
