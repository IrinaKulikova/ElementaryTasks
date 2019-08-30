using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1_Board.Services;

namespace Task1_Board.Tests
{
    [TestClass]
    public class Parser_Tests
    {
        [TestMethod]
        [DataRow(new string[] { "10", "8" })]
        [DataRow(new string[] { "2", "5" })]
        [DataRow(new string[] { "2" })]
        [DataRow(new string[] { "11", "12", "13" })]
        [DataRow(new string[] { })]
        public void GetValidArgs_Success(string[] args)
        {
            //Arrange
            var parser = new Parser();

            //Act
            var ints = parser.GetValidArgs(args);

            //Assert
            Assert.AreEqual(args.Length, ints.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [DataRow(new string[] { "&",""})]
        [DataRow(new string[] { "v", "mm" })]
        [DataRow(new string[] { "v", "2" })]
        [DataRow(new string[] { "110", "m" })]
        [DataRow(new string[] { "110", "m", "51" })]
        public void GetValidArgs_Throws_FormatException(string[] args)
        {
            //Arrange
            var parser = new Parser();

            //Act
            var ints = parser.GetValidArgs(args);

            //Assert
            Assert.AreEqual(args.Length, ints.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(new string[] { "0", "0" })]
        [DataRow(new string[] { "-5", "2" })]
        [DataRow(new string[] { "2", "0" })]
        [DataRow(new string[] { "-9" })]
        public void GetValidArgs_Throws_ArgumentException(string[] args)
        {
            //Arrage
            var parser = new Parser();

            //Act
            var ints = parser.GetValidArgs(args);

            //Assert
            Assert.AreEqual(args.Length, ints.Length);
        }


        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        [DataRow(new string[] { "10000000000000000000000000" })]
        [DataRow(new string[] { "5", "20000000000000000000000000" })]
        public void GetValidArgs_Throws_OverflowException(string[] args)
        {
            //Arrage   
            var parser = new Parser();

            //Act
            var ints = parser.GetValidArgs(args);

            //Assert
            Assert.AreEqual(args.Length, ints.Length);
        }
    }
}
