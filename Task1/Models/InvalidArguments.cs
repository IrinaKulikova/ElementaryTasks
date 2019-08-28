using System;
using Task1_Board.Models.Interfaces;

namespace Task1_Board.Models
{
    class InvalidArguments : IMessage
    {
        private readonly string message = "You shold input 2 valid arguments! ";
        private readonly string exceptionMessage = string.Empty;

        public InvalidArguments() { }

        public InvalidArguments(Exception ex)
        {
            exceptionMessage = ex.Message;
        }

        public string Message => message + exceptionMessage;
    }
}