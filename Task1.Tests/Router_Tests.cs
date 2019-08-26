using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Controllers;
using Task1.Services;

namespace Task1.Tests
{
    [TestClass]
    public class Router_Tests
    {
        [TestMethod]
        [DataRow(new int[] { 5, 6 })]
        public void GetController_BoardController_Success(int[] args)
        {
            //Arrage
            var router = new Router();

            //Act
            var controller = router.GetController(args);

            //Assert
            Assert.AreEqual(typeof(BoardController), controller.GetType());
        }

        [TestMethod]
        [DataRow(new int[] { })]
        public void GetController_InstractionController_Success(int[] args)
        {
           //Arrage
            var router = new Router();

            //Act
            var controller = router.GetController(args);

            //Assert
            Assert.AreEqual(typeof(InstractionController), controller.GetType());
        }

        [TestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]

        public void GetController_InvalidArgumentsController_Success(int[] args)
        {
            //Arrage
            var router = new Router();

            //Act
            var controller = router.GetController(args);

            //Assert
            Assert.AreEqual(typeof(InvalidArgumentsController), controller.GetType());
        }
    }
}
