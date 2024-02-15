using FluentAssertions;
using oop_backend.Controllers;
using Xunit;

namespace oop_backend_test.Controllers
{
    /// <summary>
    /// Тесты на ItemController.
    /// </summary>
    public class ItemControllerTests
    {
        /// <summary>
        /// Проверка createItem.
        /// </summary>
        [Fact]
        public void CreateItem_ReturnOK()
        {
            var controller = new ItemController();
            var result = controller.CreateItem("a", "b", 1);

            result.Value.Name.Should().Be("a");
            result.Value.Info.Should().Be("b");
            result.Value.Cost.Should().Be(1);
        }
    }
}
