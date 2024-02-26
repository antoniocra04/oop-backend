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
        /// <param name="address">Адрес.</param>
        public Customer(string fullname, string address)
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
        [StringLength(500, ErrorMessage = "Адрес должен быть меньше 500 символов")]
        public string Address { get; set; }
    }
}