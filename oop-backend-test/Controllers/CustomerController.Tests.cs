using FluentAssertions;
using oop_backend.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace oop_backend_test.Controllers
{
    public class CustomerControllerTests
    {
        [Fact]
        public void CustomerController_CreateCustomer_ReturnOK()
        {
            var controller = new CustomerController();
            var result = controller.CreateCustomer("Anton", "Tomsk");

            result.Value.FullName.Should().Be("Anton");
            result.Value.Adress.Should().Be("Tomsk");
        }
    }
}
