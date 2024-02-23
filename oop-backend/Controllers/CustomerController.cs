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
        public ActionResult<List<CustomerDto>> GetAllCustomers()
        {
            var Customers = _dbContext.Customers;
            List<CustomerDto> result = new List<CustomerDto>();
            Customers.ForEachAsync(customer =>
            {
                var address = _dbContext.Addresses.SingleOrDefault(address => address.Id == customer.AddressId);
                result.Add(new CustomerDto(customer.Fullname, address, customer.Id));
            });

            return result;
        }

        /// <summary>
        /// Эндпоинт для создания нового покупателя.
        /// </summary>
        /// <param name="newCustomer">Новый покупатель.</param>
        /// <returns>Новый покупатель.</returns>
        [HttpPost("createCustomer")]
        public ActionResult<Customer> CreateCustomer(CustomerDto newCustomer)
        {
            _dbContext.Customers.Add(new Customer(newCustomer.Fullname, newCustomer.Address.Id));
            _dbContext.Addresses.Add(newCustomer.Address);
            _dbContext.SaveChanges();

            return StatusCode(200, newCustomer);
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

            _dbContext.SaveChanges();
            return StatusCode(200, updatedCustomer);
        }

        /// <summary>
        /// Эндпоинт для удаления покупателя.
        /// </summary>
        /// <param name="id">Id покупателя.</param>
        /// <returns></returns>
        [HttpDelete("deleteCustomer/{id}")]
        public ActionResult DeleteItem(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();

            return StatusCode(200);
        }
    }
}