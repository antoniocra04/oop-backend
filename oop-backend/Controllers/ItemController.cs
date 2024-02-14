using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oop_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace oop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly Context.DBContext dbContext;

        public ItemController(Context.DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("getAllItems")]
        public ActionResult<DbSet<Item>> GetAllItems()
        {
            return dbContext.Items;
        }

        [HttpPost("createItem")]
        public ActionResult<Item> CreateItem(Item newItem)
        {
            dbContext.Items.Add(newItem);
            dbContext.SaveChanges();

            return newItem;
        }

        [HttpPut("changeItem/{id}")]
        public ActionResult<Item> ChangeItem(int id, Item updatedItem)
        {
            var item = dbContext.Items.SingleOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.Info = updatedItem.Info;
            item.Cost = updatedItem.Cost;

            dbContext.SaveChanges();

            return updatedItem;
        }
    }
}