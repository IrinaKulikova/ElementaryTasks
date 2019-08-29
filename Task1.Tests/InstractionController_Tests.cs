using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task1_Board.Controllers;
using Task1_Board.Models;
using Task1_Board.Views.BaseView;

namespace Task1_Board.Tests
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

            var controller = new InstructionController(mockView.Object, mockModel.Object);
            controller.Show();

            mockView.Verify(v => v.Display(mockModel.Object), Times.Once);
        }
    }
}
