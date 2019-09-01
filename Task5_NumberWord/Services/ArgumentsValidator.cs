using Task5_NumberWord.Services.Interfaces;

namespace Task5_NumberWord.Services
{
    public class ArgumentsValidator : IArgumentsValidator
    {
        public bool IsNumber(string number)
        {
            return int.TryParse(number, out int value);
        }
    }
}