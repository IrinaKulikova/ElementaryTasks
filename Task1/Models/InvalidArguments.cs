using System;

namespace Task1.Models
{
    class InvalidArguments : IModel
    {
        private readonly string message = "You shold input 2 valid arguments! ";
        private readonly string exceptionMessage = string.Empty;
        public InvalidArguments() { }
        public InvalidArguments(Exception ex)
        {
            exceptionMessage = ex.Message;
        }
        public override string ToString() => message + exceptionMessage;
    }
}