using CustomCollections;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task1_Board.Controllers;
using Task1_Board.Controllers.Interfaces;
using Task1_Board.Services.Interfaces;

namespace Task1_Board.Tests
{
    [TestClass]
    public class Application_Tests
    {

        [TestMethod]
        public void Start_Success()
        {
            var mockManager = new Mock<IManager>();
            var mockParser = new Mock<IParser>();
            var mockLogger = new Mock<ILogger>();

            var app = new Application(mockParser.Object, mockManager.Object, mockLogger.Object);

            var controller1 = new Mock<IController>();
            var controller2 = new Mock<IController>();

            mockParser.Setup(p => p.GetValidArgs(It.IsAny<string[]>())).Returns(It.IsAny<IArgumentCollection<int>>()).Verifiable();
            mockManager.Setup(m => m.Routing(It.IsAny<IArgumentCollection<int>>())).Returns<IController>(c => controller1.Object).Verifiable();
            mockManager.Setup(m => m.GetErrorController()).Returns<IController>(c => controller2.Object).Verifiable();

            controller1.Setup(c => c.Show());
            controller2.Setup(c => c.Show());

            app.Start(It.IsAny<string[]>());

            mockParser.Verify(p => p.GetValidArgs(It.IsAny<string[]>()), Times.Once);
            mockManager.Verify(m => m.Routing(It.IsAny<IArgumentCollection<int>>()), Times.Once);
            mockManager.Verify(r => r.GetErrorController(), Times.Between(0, 1, Range.Inclusive));

            controller1.Verify(c => c.Show(), Times.Between(0, 1, Range.Inclusive));
            controller2.Verify(c => c.Show(), Times.Between(0, 1, Range.Inclusive));
        }
    }
}
