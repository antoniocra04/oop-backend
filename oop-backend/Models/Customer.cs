using oop_backend.Models.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oop_backend.Models
{
    /// <summary>
    /// Хранит информацию о покупателе.
    /// </summary>
    [Table("customers")]
    public class Customer
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="fullname">Полное имя.</param>
        /// <param name="addressId">Id адреса.</param>
        /// <param name="cartId">Id корзины.</param>
        /// <param name="ordersIds">Заказы.</param>
        public Customer(string fullname, int addressId, int cartId, int[] ordersIds)
        {
            this.Id = IdGenerator.GetId();

            this.Fullname = fullname;
            this.AddressId = addressId;
            this.CartId = cartId;
            this.OrdersIds = ordersIds;
        }

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Возвращает и задает полное имя покупателя.
        /// </summary>
        [StringLength(200, ErrorMessage = "Имя должно быть меньше 200 символов")]
        public string Fullname { get; set; }

        /// <summary>
        /// Возвращает и задает Id адреса покупателя.
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// Возвращает и задает Id корзины покупателя.
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// Возвращает и задает список заказов
        /// </summary>
        public int[] OrdersIds { get; set; }
    }

}