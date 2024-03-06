using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        /// Создает экземпляр класса <see cref="Item"/>.
        /// </summary>
        /// <param name="name">Имя продукта.</param>
        /// <param name="info">Информация продукта.</param>
        /// <param name="cost">Цена продукта.</param>
        public Item(string name, string info, int cost, CategoryType category)
        {
            this.Id = IdGenerator.GetId();

            this.Name = name;
            this.Info = info;
            this.Cost = cost;
            this.Category = category;
        }

        /// <summary>
        /// Возвращает Id товара.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Возвращает и задает наименование товара.
        /// </summary>
        [StringLength(200, ErrorMessage = "Имя должно быть меньше 200 символов")]
        public string Name { get; set; }

        /// <summary>
        /// Возвращает и задает информацию о товаре.
        /// </summary>
        [StringLength(1000, ErrorMessage = "Информация должна быть меньше 1000 символов")]
        public string Info { get; set; }

        /// <summary>
        /// Возвращает и задает цену товара.
        /// </summary>
        [Range(0, 100000, ErrorMessage = "Цена должна быть в диапазоне от 0 до 100000")]
        public int Cost { get; set; }

        /// <summary>
        /// Возвращает и задает категорию товара.
        /// </summary>
        [EnumDataType(typeof(CategoryType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public CategoryType Category { get; set; }
    }
}