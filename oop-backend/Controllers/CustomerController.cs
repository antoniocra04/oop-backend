using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oop_backend.Models;

namespace oop_backend.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Context.DBContext dbContext;

        public CustomerController(Context.DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("getAllCustomers")]
        public ActionResult<DbSet<Customer>> GetAllCustomers()
        {
            return dbContext.Customers;
        }

        [HttpPost("createCustomer")]
        public ActionResult<Customer> CreateCustomer(Customer newCustomer)
        {
            dbContext.Add(newCustomer);
            dbContext.SaveChanges();

            return newCustomer;
        }

        [HttpPut("changeCustomer/{id}")]
        public ActionResult<Customer> ChangeCustomer(int id, Customer updatedCustomer)
        {
            var customer = dbContext.Customers.SingleOrDefault(i => i.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.Fullname = updatedCustomer.Fullname;
            customer.Adress = updatedCustomer.Adress;

            dbContext.SaveChanges();
            return updatedCustomer;
        }
    }
}