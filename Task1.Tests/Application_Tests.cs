using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Task1.Controllers.Interfaces;
using Task1.Services.Interfaces;
using Task1.Utils.Interfaces;

namespace Task1.Tests
{
    [TestClass]
    public class Application_Tests
    {
       
        [TestMethod]
        public void Start_Success()
        {
            var mockRouter = new Mock<IRouter>();
            var mockParser = new Mock<IParser>();

            var app = new Application(mockParser.Object, mockRouter.Object);

            var controller = new Mock<IController>();
            controller.Setup(c => c.Show());

            mockParser.Setup(p => p.GetValidArgs(It.IsAny<string[]>())).Returns(It.IsAny<int[]>());
            mockRouter.Setup(m => m.GetController(It.IsAny<int[]>())).Returns<IController>(c => controller.Object).Verifiable();
            mockRouter.Setup(m => m.GetErrorController(new Exception())).Returns<IController>(c => controller.Object).Verifiable();


            app.Start(It.IsAny<string[]>());

            mockParser.Verify(p => p.GetValidArgs(It.IsAny<string[]>()), Times.Once);
            mockRouter.Verify(r => r.GetController(It.IsAny<int[]>()), Times.Once);
            mockRouter.Verify(r => r.GetErrorController(new Exception()), Times.Between(0, 1, Range.Inclusive));

            controller.Verify(c => c.Show(), Times.Once);
        }
    }
}
