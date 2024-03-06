using oop_backend.Models.Utils;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace oop_backend.Models
{
    /// <summary>
    /// Хранит данные покупателя получаемые в запросе.
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="CustomerDto"/>.
        /// </summary>
        /// <param name="fullname">Полное имя.</param>
        /// <param name="address">Адрес.</param>
        /// <param name="Id">Id.</param>
        public CustomerDto(string fullname, Address address, int id, Cart cart, Order[] orders)
        {
            this.Id = id;
            this.Fullname = fullname;
            this.Address = address;
            this.Cart = cart;
            this.Orders = orders;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="CustomerDto"/>.
        /// </summary>
        /// <param name="fullname">Полное имя.</param>
        /// <param name="address">Адрес.</param>
        [JsonConstructor]
        public CustomerDto(string fullname, Address address, Cart cart, Order[] orders)
        {
            this.Id = IdGenerator.GetId();

            this.Fullname = fullname;
            this.Address = address;
            this.Cart = cart;
            this.Orders = orders;
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
        /// Возвращает и задает адрес покупателя.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Возвращает и задает корзину покупателя.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// Возвращает и задает список заказов.
        /// </summary>
        public Order[] Orders { get; set; }
    }
}
