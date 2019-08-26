namespace Task1.Models
{
    class Instraction : IModel
    {
        private readonly string message = "You should enter a width and a height. There are no valid arguments!\n";
        public override string ToString() => message;
    }
}
