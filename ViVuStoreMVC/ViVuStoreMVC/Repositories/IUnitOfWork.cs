namespace ViVuStoreMVC.Repositories
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
        IPublisherRepository Publishers { get; }

        void Complete();
    }
}