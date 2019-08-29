using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_Board.Controllers;
using Task1_Board.Services;
using Task1.Factories;

namespace Task1_Board.Tests
{
    [TestClass]
    public class Router_Tests
    {
        [TestMethod]
        [DataRow(new int[] { 5, 6 })]
        public void GetController_BoardController_Success(int[] args)
        {
            //Arrage
            var router = new Router(new BoardFactory());

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
            var router = new Router(new BoardFactory());

            //Act
            var controller = router.GetController(args);

            //Assert
            Assert.AreEqual(typeof(InstructionController), controller.GetType());
        }

        [TestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]

        public void GetController_InvalidArgumentsController_Success(int[] args)
        {
            //Arrage
            var router = new Router(new BoardFactory());

            //Act
            var controller = router.GetController(args);

            //Assert
            Assert.AreEqual(typeof(InvalidArgumentsController), controller.GetType());
        }
    }
}
