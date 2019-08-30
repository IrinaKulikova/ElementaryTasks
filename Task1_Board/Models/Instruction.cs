using Task1_Board.Models.Interfaces;

namespace Task1_Board.Models
{
    class Instruction : IMessage
    {
        private readonly string message = "You should enter a width and a height. There are no valid arguments!\n";
        public string Message => message;
    }
}
