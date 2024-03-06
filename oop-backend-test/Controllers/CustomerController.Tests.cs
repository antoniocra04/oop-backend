using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using oop_backend.Context;
using oop_backend.Controllers;
using oop_backend.Models;
using System.Diagnostics;
using Xunit;

namespace oop_backend_test.Controllers
{
    /// <summary>
    /// Тесты на CustomerController.
    /// </summary>
    public class CustomerControllerTests
    {
        private DbContextOptions<DBContext> contextOptions = new DbContextOptionsBuilder<DBContext>()
        .UseInMemoryDatabase("oop-back")
        .Options;

        /// <summary>
        /// Проверка CreateCustomer.
        /// </summary>
        [Fact]
        public void CreateCustomer_ReturnOK()
        {
            using var dbContext = new DBContext(contextOptions);
            var controller = new CustomerController(dbContext);

            CustomerDto newCustomer = new CustomerDto("Anton", new Address("999999", "Russia", "Tomsk", "building", "21"));
            
            var result = controller.CreateCustomer(newCustomer);
            Debug.WriteLine(result);
            result.Should().NotBeNull();
        }
    }
}
