using CustomCollections;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var mockManager = new Mock<IControllerDictionary>();
            var mockValidator = new Mock<IArgumentsValidator>();
            var mockLogger = new Mock<ILogger>();

            var app = new Application(mockValidator.Object, mockManager.Object, mockLogger.Object);

            var controller1 = new Mock<IController>();
            var controller2 = new Mock<IController>();

           /* mockValidator.Setup(v => v.IsValidInputArguments(It.IsAny<string[]>(), It.IsNotNull<IArgumentCollection<int>>()))
                .Returns(It.IsAny<bool>()).Verifiable();
            mockManager.Setup(m => m.GetController(It.IsAny<IArgumentCollection<int>>()))
                .Returns<IController>(c => controller1.Object).Verifiable();
            mockManager.Setup(m => m.InvalidArguments()).Returns<IController>(c => controller2.Object).Verifiable();

            controller1.Setup(c => c.Show());
            controller2.Setup(c => c.Show());

            app.Start(It.IsAny<string[]>());

            mockValidator.Verify(p => p.IsValidInputArguments(It.IsAny<string[]>(), It.IsNotNull<IArgumentCollection<int>>()), Times.Once);
            mockManager.Verify(m => m.GetController(It.IsAny<IArgumentCollection<int>>()), Times.Once);
            mockManager.Verify(r => r.InvalidArguments(), Times.Between(0, 1, Range.Inclusive));

            controller1.Verify(c => c.Show(), Times.Between(0, 1, Range.Inclusive));
            controller2.Verify(c => c.Show(), Times.Between(0, 1, Range.Inclusive));*/
        }
    }
}
