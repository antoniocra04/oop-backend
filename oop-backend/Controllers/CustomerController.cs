using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oop_backend.Models;
using oop_backend.Context;

namespace oop_backend.Controllers
{
    /// <summary>
    /// Контроллер продуктов.
    /// </summary>
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Контекст данных для БД.
        /// </summary>
        private readonly DBContext _dbContext;

        /// <summary>
        /// Создает экземпляр класса.<see cref="CustomerController"/>
        /// </summary>
        /// <param name="dbContext">Контекст данных для БД.</param>
        public CustomerController(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Эндпоинт для получения всех покупателей.
        /// </summary>
        /// <returns>Список всех покупателей.</returns>
        [HttpGet("getAllCustomers")]
        public ActionResult<DbSet<Customer>> GetAllCustomers()
        {
            return _dbContext.Customers;
        }

        /// <summary>
        /// Эндпоинт для создания нового покупателя.
        /// </summary>
        /// <param name="newCustomer">Новый покупатель.</param>
        /// <returns>Новый покупатель.</returns>
        [HttpPost("createCustomer")]
        public ActionResult<Customer> CreateCustomer(Customer newCustomer)
        {
            _dbContext.Add(newCustomer);
            _dbContext.SaveChanges();

            return newCustomer;
        }

        /// <summary>
        /// Эндпоинт для изменения покупателя.
        /// </summary>
        /// <param name="id">Id покупателя.</param>
        /// <param name="updatedCustomer">Изменненый покупатель.</param>
        /// <returns>Измененный покупатель.</returns>
        [HttpPut("changeCustomer/{id}")]
        public ActionResult<Customer> ChangeCustomer(int id, Customer updatedCustomer)
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Fullname = updatedCustomer.Fullname;
            customer.Address = updatedCustomer.Address;

            _dbContext.SaveChanges();
            return updatedCustomer;
        }
    }
}