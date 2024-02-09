using oop_backend.Models.Utils;
using System.ComponentModel.DataAnnotations;

namespace oop_backend.Models
{
    /// <summary>
    /// Класс покупатель
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// id покупателя
        /// </summary>
        private readonly int _id;
        public int Id { get { return _id; } }

        /// <summary>
        /// полное имя покупателя
        /// </summary>
        [StringLength(200, ErrorMessage = "Имя должно быть меньше 200 символов")]
        private string _fullname;
        public string FullName { get { return _fullname; } }

        /// <summary>
        /// адресс покупателя
        /// </summary>
        [StringLength(500 , ErrorMessage = "Адрес должен быть меньше 500 символов")]
        private string _adress;
        public string Adress { get { return _adress; } }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fullname">полное имя</param>
        /// <param name="adress">адресс</param>
        public Customer(string fullname, string adress)
        {
            this._id = new IdGenerator().GetId();

            this._fullname = fullname;
            this._adress = adress;
        }
    }
}
