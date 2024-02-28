using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oop_backend.Models;
using oop_backend.Context;

namespace oop_backend.Controllers
{
    /// <summary>
    /// Контроллер адресов.
    /// </summary>
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// Контекст данных для БД.
        /// </summary>
        private readonly DBContext _dbContext;

        /// <summary>
        /// Создает экземпляр класса.<see cref="CustomerController"/>.
        /// </summary>
        /// <param name="dbContext">Контекст данных для БД.</param>
        public AddressController(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Эндпоинт для получения всех адресов.
        /// </summary>
        /// <returns>Список всех адресов.</returns>
        [HttpGet]
        public ActionResult<DbSet<Address>>GetAllAddresses()
        {
            return _dbContext.Addresses;
        }

        /// <summary>
        /// Эндпоинт для удаления адреса.
        /// </summary>
        /// <param name="id">Id адреса.</param>
        /// <returns>Статус запроса</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteAddress(int id)
        {
            var address = _dbContext.Addresses.SingleOrDefault(address => address.Id == id);

            if (address == null)
            {
                return NotFound();
            }

            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();

            return StatusCode(200);
        }
    }
}
