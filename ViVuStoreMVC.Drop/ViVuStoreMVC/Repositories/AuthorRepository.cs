using System.Collections.Generic;
using System.Linq;
using ViVuStoreMVC.Data;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ViVuStoreDbContext _context;

        public AuthorRepository(ViVuStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }
    }
}
