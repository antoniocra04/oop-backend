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
        /// Контекст данных для БД.
        /// </summary>
        private readonly DBContext _dbContext;

        /// <summary>
        /// Создает экземпляр класса.<see cref="ItemController"/>.
        /// </summary>
        /// <param name="dbContext">Контекст данных для БД.</param>
        public ItemController(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Эндпоинт для получения всех продуктов.
        /// </summary>
        /// <returns>Список продуктов.</returns>
        [HttpGet("getAllItems")]
        public ActionResult<DbSet<Item>> GetAllItems()
        {
            return _dbContext.Items;
        }

        /// <summary>
        /// Эндпоинт для создания продукта.
        /// </summary>
        /// <param name="newItem">Новый продукт.</param>
        /// <returns>Новый продукт.</returns>
        [HttpPost("createItem")]
        public ActionResult<Item> CreateItem(Item newItem)
        {
            _dbContext.Items.Add(newItem);
            _dbContext.SaveChanges();

            return newItem;
        }

        /// <summary>
        /// Эндпоинт для изменения продукта.
        /// </summary>
        /// <param name="id">Id продукта.</param>
        /// <param name="updatedItem">Измененный продукт.</param>
        /// <returns>Измененный продукт.</returns>
        [HttpPut("changeItem/{id}")]
        public ActionResult<Item> ChangeItem(int id, Item updatedItem)
        {
            var item = _dbContext.Items.SingleOrDefault(item => item.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.Name = updatedItem.Name;
            item.Info = updatedItem.Info;
            item.Cost = updatedItem.Cost;
            item.Category = updatedItem.Category;

            _dbContext.SaveChanges();

            return updatedItem;
        }
        
        /// <summary>
        /// Эндпоинт для удаления продукта.
        /// </summary>
        /// <param name="id">Id продукта.</param>
        /// <returns>Статус запроса</returns>
        [HttpDelete("deleteItem/{id}")]
        public ActionResult DeleteItem(int id)
        {
            var item = _dbContext.Items.SingleOrDefault(item => item.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            _dbContext.Items.Remove(item);
            _dbContext.SaveChanges();

            return StatusCode(200);
        }
    }
}