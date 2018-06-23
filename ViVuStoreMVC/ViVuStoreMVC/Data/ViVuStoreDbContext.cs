using Microsoft.EntityFrameworkCore;

namespace ViVuStoreMVC.Data
{
    public class ViVuStoreDbContext : DbContext
    {
        public ViVuStoreDbContext(DbContextOptions<ViVuStoreDbContext> options) : base(options)
        {
        }


    }
}
