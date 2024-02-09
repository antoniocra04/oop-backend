using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oop_backend.Models;

namespace oop_backend.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        [HttpPost("createItem")]
        public ActionResult<Item> CreateItem(string name, string info, int cost)
        {
            return new Item(name, info, cost);
        }
    }
}
