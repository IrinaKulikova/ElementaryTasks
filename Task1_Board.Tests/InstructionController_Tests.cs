using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
            var mockModel = new Mock<IModel>();
            var mockView = new Mock<ConsoleView>(MockBehavior.Default, new object[] { ConsoleColor.Red, mockModel.Object });

            mockView.Setup(v => v.Display());
            var controller = new InstructionController(mockView.Object, mockModel.Object);
            
            controller.Show();

            mockView.Verify(v => v.Display(), Times.Once);
        }
    }
}
