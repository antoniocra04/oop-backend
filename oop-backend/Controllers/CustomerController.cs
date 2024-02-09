using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oop_backend.Models;

namespace oop_backend.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost("createCustomer")]
        public ActionResult<Customer> CreateCustomer(string fullname, string adress)
        {
            return new Customer(fullname, adress);
        }
    }
}
