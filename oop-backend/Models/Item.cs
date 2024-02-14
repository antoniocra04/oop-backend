using oop_backend.Models.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oop_backend.Models
{
    /// <summary>
    /// Класс товара
    /// </summary>
    [Table("items")]
    public class Item
    {
        /// <summary>
        /// id товара
        /// </summary>
        private readonly int _id;
        public int Id { get { return _id; } }

        /// <summary>
        /// наименование товара
        /// </summary>
        [StringLength(200, ErrorMessage = "Имя должно быть меньше 200 символов")]
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// Информация о товаре
        /// </summary>
        [StringLength(1000, ErrorMessage = "Информация должна быть меньше 1000 символов")]
        private string _info;
        public string Info { get { return _info; } set { _info = value; } }

        /// <summary>
        /// Цена товара
        /// </summary>
        [Range(0, 100000, ErrorMessage = "Цена должна быть в диапазоне от 0 до 100000")]
        private int _cost;
        public int Cost { get { return _cost; } set { _cost = value; } }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="info">информация</param>
        /// <param name="cost">цена</param>
        /// <param name="category">категория</param>
        public Item(string name, string info, int cost)
        {
            this._id = new IdGenerator().GetId();

            this._name = name;
            this._info = info;
            this._cost = cost;
        }
    }
}