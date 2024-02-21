namespace oop_backend.Models
{
    /// <summary>
    /// Хранит информацию об адресе
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
        public Address(int index, string country, string city, string building, string apartment)
        {
            this.Index = index;
            this.Country = country;
            this.City = city;
            this.Building = building;
            this.Apartment = apartment;
        }

        /// <summary>
        /// Индекс.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Дом.
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Квартира.
        /// </summary>
        public string Apartment { get; set; }

    }
}
