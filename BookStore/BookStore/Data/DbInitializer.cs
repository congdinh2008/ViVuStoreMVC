namespace BookStore.Data
{
    public static class DbInitializer
    {
        public static void Initializer(this BookStoreDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
