using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class Validator : IValidator
    {
        public bool IsNumber(string[] args)
        {
            return (args.Length == 1 || args.Length == 2) && int.TryParse(args[0], out int value);
        }
    }
}