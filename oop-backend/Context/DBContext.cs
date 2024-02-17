using Microsoft.EntityFrameworkCore;
using oop_backend.Models;

namespace oop_backend.Context
{

    /// <summary>
    /// БД.
    /// </summary>
    public class DBContext: DbContext
    {
        /// <summary>
        /// Товары.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Покупатели.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="DBContext"/>
        /// </summary>
        /// <param name="options">Дополнительные параметры для бд.</param>
        public DBContext(DbContextOptions options)
            : base(options)
        {}

        /// <summary>
        /// Метод переопределения стандартных настроек бд.
        /// </summary>
        /// <param name="modelBuilder">Класс для конфигурирования бд.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasAlternateKey(i => i.Id);
            modelBuilder.Entity<Customer>().HasAlternateKey(c => c.Id);
        }
    }
}
