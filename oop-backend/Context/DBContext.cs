﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        /// Возвращает и задает товары.
        /// </summary>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        /// Возвращает и задает покупателей.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Возвращает и задает адреса.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Возвращает и задает корзины.
        /// </summary>
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// Возвращает и задает заказы.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Метод переопределения стандартных настроек бд.
        /// </summary>
        /// <param name="modelBuilder">Класс для конфигурирования бд.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<int[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val)).ToArray());

            modelBuilder.Entity<Item>().HasAlternateKey(item => item.Id);
            modelBuilder.Entity<Address>().HasAlternateKey(address => address.Id);

            modelBuilder.Entity<Customer>().HasAlternateKey(customer => customer.Id);
            modelBuilder.Entity<Customer>().Property(customer => customer.OrdersIds).HasConversion(converter);

            modelBuilder.Entity<Cart>().HasAlternateKey(cart => cart.Id);
            modelBuilder.Entity<Cart>().Property(cart => cart.Items).HasConversion(converter);

            modelBuilder.Entity<Order>().HasAlternateKey(order => order.Id);
            modelBuilder.Entity<Order>().Property(order => order.Items).HasConversion(converter);
        }
    }
}
