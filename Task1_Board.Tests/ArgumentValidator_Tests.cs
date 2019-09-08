using CustomCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_Board.Services;

namespace Task1_Board.Tests
{
    [TestClass]
    public class ArgumentValidator_Tests
    {
        [TestMethod]
        [DataRow(new string[] { "10", "8" })]
        [DataRow(new string[] { "2", "5" })]
        [DataRow(new string[] { "2" })]
        [DataRow(new string[] { "11", "12", "13" })]
        [DataRow(new string[] { })]
        public void GetValidArgs_Success(string[] args)
        {
            //Arrage   
            var logger = new TestLogger();
            var validator = new ArgumentsValidator(logger);
            var collection = new ArgumentCollection<int>();

            //Act
            var result = validator.IsValidInputArguments(args, collection);

            //Assert
            Assert.AreEqual(args.Length, collection.Count);
        }
                

        [TestMethod]
        [DataRow(new string[] { "&", "" })]
        [DataRow(new string[] { "v", "mm" })]
        [DataRow(new string[] { "v", "2" })]
        [DataRow(new string[] { "110", "m" })]
        [DataRow(new string[] { "110", "m", "51" })]
        [DataRow(new string[] { "10000000000000000000000000" })]
        [DataRow(new string[] { "5", "20000000000000000000000000" })]
        [DataRow(new string[] { "0", "0" })]
        [DataRow(new string[] { "-5", "2" })]
        [DataRow(new string[] { "2", "0" })]
        [DataRow(new string[] { "-9" })]
        public void IsValidInputArguments_Fail(string[] args)
        {
            //Arrage   
            var logger = new TestLogger();
            var validator = new ArgumentsValidator(logger);
            var collection = new ArgumentCollection<int>();

            //Act
            var result = validator.IsValidInputArguments(args, collection);

            //Assert
            Assert.AreNotEqual(args.Length, collection.Count);
        }
    }
}
