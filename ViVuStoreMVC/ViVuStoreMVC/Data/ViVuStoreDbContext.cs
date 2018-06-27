using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ViVuStoreMVC.Auth;
using ViVuStoreMVC.Models;

namespace ViVuStoreMVC.Data
{
    public class ViVuStoreDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ViVuStoreDbContext(DbContextOptions<ViVuStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
