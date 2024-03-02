using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using oop_backend.Context;
using oop_backend.Controllers;
using oop_backend.Models;
using Xunit;

namespace oop_backend_test.Controllers
{
    /// <summary>
    /// Тесты на ItemController.
    /// </summary>
    public class ItemControllerTests
    {
        private DbContextOptions<DBContext> contextOptions = new DbContextOptionsBuilder<DBContext>()
        .UseInMemoryDatabase("oop-back")
        .Options;

        /// <summary>
        /// Проверка CreateItem.
        /// </summary>
        [Fact]
        public void CreateItem_ReturnOK()
        {
            using var dbContext = new DBContext(contextOptions);
            var controller = new ItemController(dbContext);

            var result = controller.CreateItem(new Item("name", "info", 999, CategoryType.Laptop));

            result.Value.Should().NotBeNull();
        }
    }
}
