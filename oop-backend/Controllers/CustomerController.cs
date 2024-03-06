using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oop_backend.Models;
using oop_backend.Context;
using System;

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
        /// Создает экземпляр класса <see cref="CustomerController"/>.
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
            var сustomers = _dbContext.Customers;
            List<CustomerDto> result = new List<CustomerDto>();
            сustomers.ForEachAsync(customer =>
            {
                var address = _dbContext.Addresses.SingleOrDefault(address => address.Id == customer.AddressId);
                var cart = _dbContext.Carts.SingleOrDefault(cart => cart.Id == customer.CartId);

                var orders = _dbContext.Orders.Where(order => customer.Orders.Contains(order.Id)).ToArray();

                result.Add(new CustomerDto(customer.Fullname, address, customer.Id, cart, orders));
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
            int[] orders = newCustomer.Orders.Select(order => order.Id).ToArray();

            _dbContext.Customers.Add(new Customer(newCustomer.Fullname, newCustomer.Address.Id, newCustomer.Cart.Id, orders));
            _dbContext.Addresses.Add(newCustomer.Address);
            _dbContext.Carts.Add(newCustomer.Cart);
            _dbContext.SaveChanges();

            return StatusCode(200, newCustomer);
        }

        /// <summary>
        /// Эндпоинт для изменения покупателя.
        /// </summary>
        /// <param name="id">Id покупателя.</param>
        /// <param name="updatedCustomer">Измененный покупатель.</param>
        /// <returns>Измененный покупатель.</returns>
        [HttpPut("changeCustomer/{id}")]
        public ActionResult<Customer> ChangeCustomer(int id, CustomerDto updatedCustomer)
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Fullname = updatedCustomer.Fullname;

            var address = _dbContext.Addresses.SingleOrDefault(address => address.Id == customer.AddressId);

            if (address == null)
            {
                return NotFound();
            }

            address.Index = updatedCustomer.Address.Index;
            address.Country = updatedCustomer.Address.Country;
            address.City = updatedCustomer.Address.City;
            address.Building = updatedCustomer.Address.Building;
            address.Apartment = updatedCustomer.Address.Apartment;

            _dbContext.SaveChanges();
            return StatusCode(200, updatedCustomer);
        }

        /// <summary>
        /// Эндпоинт для удаления покупателя.
        /// </summary>
        /// <param name="id">Id покупателя.</param>
        /// <returns>Статус запроса.</returns>
        [HttpDelete("deleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            
            var address = _dbContext.Addresses.SingleOrDefault(address => address.Id == customer.AddressId);

            if (address == null)
            {
                return NotFound();
            }

            var cart = _dbContext.Carts.SingleOrDefault(cart => cart.Id == customer.CartId);

            if (cart == null)
            {
                return NotFound();
            }

            _dbContext.Addresses.Remove(address);
            _dbContext.Customers.Remove(customer);
            _dbContext.Carts.Remove(cart);
            _dbContext.SaveChanges();

            return StatusCode(200);
        }

        /// <summary>
        /// Эндпоинт для создания заказа.
        /// </summary>
        /// <param name="id">Id покупателя.</param>
        /// <returns>Статус запроса.</returns>
        [HttpPost("createOrder")]
        public ActionResult CreateOrder(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var address = _dbContext.Addresses.SingleOrDefault(address => address.Id == customer.AddressId);

            if (address == null)
            {
                return NotFound();
            }

            var cart = _dbContext.Carts.SingleOrDefault(cart => cart.Id == customer.CartId);

            if (cart == null)
            {
                return NotFound();
            }

            DateTime dateTime = DateTime.UtcNow.Date;

            Order newOrder = new Order(dateTime.ToString("dd/MM/yyyy"), address.GetFullAddress(), cart.Items, OrderStatusType.New);
            customer.Orders = customer.Orders.Append(newOrder.Id).ToArray();
            cart.Items = new int[0];

            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();

            return StatusCode(200);
        }

        /// <summary>
        /// Эндпоинт для добавления продукта в корзину.
        /// </summary>
        /// <param name="id">Id покупателя.</param>
        /// <param name="itemId"></param>
        /// <returns>Статус запроса.</returns>
        [HttpPost("addItemInCart")]
        public ActionResult AddItemInCart(int id, int itemId)
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var cart = _dbContext.Carts.SingleOrDefault(cart => cart.Id == customer.CartId);

            if (cart == null)
            {
                return NotFound();
            }

            var item = _dbContext.Items.SingleOrDefault(item => item.Id == itemId);

            if (item == null)
            {
                return NotFound();
            }

            cart.Items = cart.Items.Append(itemId).ToArray();

            _dbContext.SaveChanges();

            return StatusCode(200);
        }

        [HttpDelete("deleteItemFromCart")]
        public ActionResult DeleteItemFromCart(int id, int itemId)
        {
            var customer = _dbContext.Customers.SingleOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var cart = _dbContext.Carts.SingleOrDefault(cart => cart.Id == customer.CartId);

            if (cart == null)
            {
                return NotFound();
            }

            var item = _dbContext.Items.SingleOrDefault(item => item.Id == itemId);

            if (item == null)
            {
                return NotFound();
            }

            cart.Items = cart.Items.Where(item => item != itemId).ToArray();  
            _dbContext.SaveChanges();
            
            return StatusCode(200);
        }

    }
}