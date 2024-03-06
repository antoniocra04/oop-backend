using Microsoft.EntityFrameworkCore;
using oop_backend.Models.Utils;
using oop_backend.Context;

namespace oop_backend.Models
{
    /// <summary>
    /// Хранит информацию о заказе.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="createDate">Дата создания заказа.</param>
        /// <param name="deliveryAddress">Адрес доставки.</param>
        /// <param name="items">Список продуктов.</param>
        /// <param name="orderStatus">Статус заказа.</param>
        public Order(string createDate, string deliveryAddress, int[] items, OrderStatusType orderStatus)
        {
            this.Id = IdGenerator.GetId();
            this.Items = items;
            this.DeliveryAddress = deliveryAddress;
            this.OrderStatus = orderStatus;
            this.CreateDate = createDate;
        }

        /// <summary>
        /// Контекст бд.
        /// </summary>
        private DbContextOptions<DBContext> contextOptions = new DbContextOptionsBuilder<DBContext>()
       .UseInMemoryDatabase("oop-back")
       .Options;

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Возвращает адрес доставки.
        /// </summary>
        public string DeliveryAddress { get; set; }

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
                using var dbContext = new DBContext(contextOptions);
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

        /// <summary>
        /// Возвращает и задает статус заказа.
        /// </summary>
        public OrderStatusType OrderStatus { get; set; }
    }
}
