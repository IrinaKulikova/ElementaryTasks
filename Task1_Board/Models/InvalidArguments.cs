using Task1_Board.Models.Interfaces;

namespace Task1_Board.Models
{
    class InvalidArguments : IMessage
    {
        private readonly string message = "You shold input two valid arguments! ";
        public string Message => message;
    }
}
