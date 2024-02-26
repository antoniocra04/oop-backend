using FluentAssertions;
using oop_backend.Controllers;
using Xunit;

namespace oop_backend_test.Controllers
{
    /// <summary>
    /// Тесты на CustomerController.
    /// </summary>
    public class CustomerControllerTests
    {
        /// <summary>
        /// Проверка CreateCustomer.
        /// </summary>
        [Fact]
        public void CreateCustomer_ReturnOK()
        {
            var controller = new CustomerController();
            var result = controller.CreateCustomer("Anton", "Tomsk");

            result.Value.Fullname.Should().Be("Anton");
            result.Value.Address.Should().Be("Tomsk");
        }
    }
}
