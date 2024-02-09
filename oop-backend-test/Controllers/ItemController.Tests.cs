using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using oop_backend.Controllers;
using Xunit;

namespace oop_backend_test.Controllers
{
    public class ItemControllerTests
    {
        [Fact]
        public void ItemController_CreateItem_ReturnOK()
        {
            var controller = new ItemController();
            var result = controller.CreateItem("a", "b", 1);

            result.Value.Name.Should().Be("a");
            result.Value.Info.Should().Be("b");
            result.Value.Cost.Should().Be(1);
        }
    }
}
