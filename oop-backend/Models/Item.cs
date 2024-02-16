using oop_backend.Models.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oop_backend.Models
{
    /// <summary>
    /// Хранит информацию о товаре.
    /// </summary>
    [Table("items")]
    public class Item
    {
        /// <summary>
        /// Id товара.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Наименование товара.
        /// </summary>
        [StringLength(200, ErrorMessage = "Имя должно быть меньше 200 символов")]
        public string Name { get; set; }

        /// <summary>
        /// Информация о товаре.
        /// </summary>
        [StringLength(1000, ErrorMessage = "Информация должна быть меньше 1000 символов")]
        public string Info { get; set; }

        /// <summary>
        /// Цена товара.
        /// </summary>
        [Range(0, 100000, ErrorMessage = "Цена должна быть в диапазоне от 0 до 100000")]
        public int Cost { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Item"/>
        /// </summary>
        /// <param name="name">Имя продукта.</param>
        /// <param name="info">Информация продукта.</param>
        /// <param name="cost">Цена продукта.</param>
        public Item(string name, string info, int cost)
        {
            this.Id = IdGenerator.GetId();

            this.Name = name;
            this.Info = info;
            this.Cost = cost;
        }
    }
}