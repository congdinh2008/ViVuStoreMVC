using ViVuStoreMVC.Data;

namespace ViVuStoreMVC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViVuStoreDbContext _context;
        public IBookRepository Books { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IAuthorRepository Authors { get; private set; }
        public IPublisherRepository Publishers { get; private set; }

        public UnitOfWork(ViVuStoreDbContext context)
        {
            _context = context;
            Books = new BookRepository(context);
            Categories = new CategoryRepository(context);
            Authors = new AuthorRepository(context);
            Publishers = new PublisherRepository(context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
