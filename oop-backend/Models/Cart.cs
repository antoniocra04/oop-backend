using Microsoft.EntityFrameworkCore;
using oop_backend.Context;
using oop_backend.Models.Utils;

namespace oop_backend.Models
{
    /// <summary>
    /// Хранит информацию о корзине с товарами.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Контекст бд.
        /// </summary>
        private DbContextOptions<DBContext> _contextOptions = new DbContextOptionsBuilder<DBContext>()
            .UseInMemoryDatabase("oop-back")
            .Options;

        /// <summary>
        /// Создает экземпляр класса <see cref="Cart"/>.
        /// </summary>
        /// <param name="items">Массив id продуктов.</param>
        public Cart(int[] items)
        {
            this.Id = IdGenerator.GetId();
            this.Items = items;
        }

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Возвращает и задает массив id продуктов.
        /// </summary>
        public int[] Items { get; set; }

        /// <summary>
        /// Возвращает общую стоимость.
        /// </summary>
        public int Amount 
        { 
            get 
            {
                var amount = 0;
                using var dbContext = new DBContext(_contextOptions);
                for (int i = 0; i < Items.Length; i++)
                {
                    var item = dbContext.Items.FirstOrDefault(item => item.Id == this.Items[i]);

                    if (item != null)
                    {
                        amount += item.Cost;
                    }
                }

                return amount;

            } 
        }
    }
}
