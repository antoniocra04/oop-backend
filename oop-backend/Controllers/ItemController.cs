using Microsoft.AspNetCore.Mvc;
using oop_backend.Models;
using Microsoft.EntityFrameworkCore;
using oop_backend.Context;

namespace oop_backend.Controllers
{
    /// <summary>
    /// Контроллер продуктов.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        /// <summary>
        /// БД.
        /// </summary>
        private readonly DBContext dbContext;

        /// <summary>
        /// Создает экземпляр класса <see cref="ItemController"/>
        /// </summary>
        /// <param name="dbContext">БД.</param>
        public ItemController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Эндпоинт для получения всех продуктов.
        /// </summary>
        /// <returns>DbSet<Item></returns>
        [HttpGet("getAllItems")]
        public ActionResult<DbSet<Item>> GetAllItems()
        {
            return dbContext.Items;
        }

        /// <summary>
        /// Эндпоинт для создания продукта.
        /// </summary>
        /// <param name="newItem">Новый продукт.</param>
        /// <returns>Item</returns>
        [HttpPost("createItem")]
        public ActionResult<Item> CreateItem(Item newItem)
        {
            dbContext.Items.Add(newItem);
            dbContext.SaveChanges();

            return newItem;
        }

        /// <summary>
        /// Эндпоинт для изменения продукта.
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <param name="updatedItem">Измененный продукт.</param>
        /// <returns>Item</returns>
        [HttpPut("changeItem/{id}")]
        public ActionResult<Item> ChangeItem(int id, Item updatedItem)
        {
            var item = dbContext.Items.SingleOrDefault(item => item.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.Name = updatedItem.Name;
            item.Info = updatedItem.Info;
            item.Cost = updatedItem.Cost;

            dbContext.SaveChanges();

            return updatedItem;
        }
    }
}