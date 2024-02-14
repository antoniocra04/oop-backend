namespace oop_backend.Context
{
    using Microsoft.EntityFrameworkCore;
    using oop_backend.Models;

    public class DBContext
        : DbContext
    {
        public DBContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasAlternateKey(i => i.Id);
            modelBuilder.Entity<Customer>().HasAlternateKey(c => c.Id);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
