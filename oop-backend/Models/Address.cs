using oop_backend.Models.Utils;
using System.ComponentModel.DataAnnotations;

namespace oop_backend.Models
{
    /// <summary>
    /// Хранит информацию об адресе.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="Address"/>.
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <param name="country">Страна.</param>
        /// <param name="city">Город.</param>
        /// <param name="building">Дом.</param>
        /// <param name="apartment">Квартира.</param>
        public Address(string index, string country, string city, string building, string apartment)
        {
            this.Id = IdGenerator.GetId();
            this.Index = index;
            this.Country = country;
            this.City = city;
            this.Building = building;
            this.Apartment = apartment;
        }

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Возвращает и задает индекс.
        /// </summary>
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Characters are not allowed.")]
        public string Index { get; set; }

        /// <summary>
        /// Возвращает и задает страну.
        /// </summary>
        [StringLength(50, ErrorMessage = " Страна должна быть меньше 50 символов")]
        public string Country { get; set; }

        /// <summary>
        /// Возвращает и задает город.
        /// </summary>
        [StringLength(30, ErrorMessage = " Город должен быть меньше 30 символов")]
        public string City { get; set; }

        /// <summary>
        /// Возвращает и задает дом.
        /// </summary>
        [StringLength(20, ErrorMessage = "Дом должен быть меньше 20 символов")]
        public string Building { get; set; }

        /// <summary>
        /// Возвращает и задает квартиру.
        /// </summary>
        [StringLength(10, ErrorMessage = " Квартира должна быть меньше 10 символов")]
        public string Apartment { get; set; }

    }
}
