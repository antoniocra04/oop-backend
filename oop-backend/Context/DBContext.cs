using Microsoft.EntityFrameworkCore;
using oop_backend.Models;

namespace oop_backend.Context
{

    /// <summary>
    /// Контекст данных для БД.
    /// </summary>
    public class DBContext: DbContext
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="DBContext"/>.
        /// </summary>
        /// <param name="options">Дополнительные параметры для бд.</param>
        public DBContext(DbContextOptions options)
            : base(options)
        {}

        /// <summary>
        /// Товары.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Покупатели.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Адреса.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Метод переопределения стандартных настроек бд.
        /// </summary>
        /// <param name="modelBuilder">Класс для конфигурирования бд.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasAlternateKey(item => item.Id);
            modelBuilder.Entity<Customer>().HasAlternateKey(customer => customer.Id);
            modelBuilder.Entity<Address>().HasAlternateKey(address => address.Id);
        }
    }
}
