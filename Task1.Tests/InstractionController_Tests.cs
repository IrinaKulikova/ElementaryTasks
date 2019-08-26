using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task1.Controllers;
using Task1.Models;
using Task1.Views;

namespace Task1.Tests
{
    [TestClass]
    public class InstractionController_Tests
    {
        [TestMethod]
        public void Show_Success()
        {
            var mockView = new Mock<ConsoleView>();
            var mockModel = new Mock<IModel>();

            mockView.Setup(v => v.Display(mockModel.Object));

            var controller = new InstractionController(mockView.Object, mockModel.Object);
            controller.Show();

            mockView.Verify(v => v.Display(mockModel.Object), Times.Once);
        }
    }
}
