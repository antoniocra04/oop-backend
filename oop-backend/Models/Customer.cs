using Newtonsoft.Json;
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
        /// Создает экземпляр класса <see cref="Customer"/>
        /// </summary>
        /// <param name="fullname">Полное имя.</param>
        /// <param name="addressId">Id Адреса.</param>
        public Customer(string fullname, int addressId)
        {
            this.Id = IdGenerator.GetId();

            this.Fullname = fullname;
            this.AddressId = addressId;
        }

        /// <summary>
        /// Id покупателя.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Полное имя покупателя.
        /// </summary>
        [StringLength(200, ErrorMessage = "Имя должно быть меньше 200 символов")]
        public string Fullname { get; set; }

        /// <summary>
        /// Адрес покупателя.
        /// </summary>
        public int AddressId { get; set; }
    }

    public class CustomerDto
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="CustomerDto"/>.
        /// </summary>
        /// <param name="fullname">Полное имя.</param>
        /// <param name="address">Адрес.</param>
        /// <param name="Id">Id.</param>
        public CustomerDto(string fullname, Address address, int id)
        {
            this.Id = id;
            this.Fullname = fullname;
            this.Address = address;
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="CustomerDto"/>
        /// </summary>
        /// <param name="fullname">Полное имя.</param>
        /// <param name="address">Адрес.</param>
        [JsonConstructor]
        public CustomerDto(string fullname, Address address)
        {
            this.Id = IdGenerator.GetId();

            this.Fullname = fullname;
            this.Address = address;
        }

        /// <summary>
        /// Id покупателя.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Полное имя покупателя.
        /// </summary>
        [StringLength(200, ErrorMessage = "Имя должно быть меньше 200 символов")]
        public string Fullname { get; set; }

        /// <summary>
        /// Адрес покупателя.
        /// </summary>
        public Address Address { get; set; }
    }
}