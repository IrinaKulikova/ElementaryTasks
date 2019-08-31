using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Task1_Board.Controllers;
using Task1_Board.Services.Interfaces;

namespace Task1_Board.Tests
{
    [TestClass]
    public class Application_Tests
    {
       
        [TestMethod]
        public void Start_Success()
        {
            var mockRouter = new Mock<IManager>();
            var mockParser = new Mock<IParser>();
            var mockLogger = new Mock<ILogger>();

            var app = new Application(mockParser.Object, mockRouter.Object, mockLogger.Object);

            var controller = new Mock<Controller>();
            controller.Setup(c => c.Show());

            mockParser.Setup(p => p.GetValidArgs(It.IsAny<string[]>())).Returns(It.IsAny<int[]>());
            mockRouter.Setup(m => m.GetController(It.IsAny<int[]>())).Returns<Controller>(c => controller.Object);
            mockRouter.Setup(m => m.GetErrorController()).Returns<Controller>(c => controller.Object);
            
            app.Start(It.IsAny<string[]>());

            mockParser.Verify(p => p.GetValidArgs(It.IsAny<string[]>()), Times.Once);
            mockRouter.Verify(r => r.GetController(It.IsAny<int[]>()), Times.Once);
            mockRouter.Verify(r => r.GetErrorController(), Times.Between(0, 1, Range.Inclusive));

            controller.Verify(c => c.Show(), Times.Once);
        }
    }
}
