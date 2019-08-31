using Task2_Envelopes.Enums;
using Task2_Envelopes.Services.Interfaces;

namespace Task2_Envelopes.Services
{
    public class ValidatorArguments : IValidator
    {
        public bool IsValid(string[] args)
        {
            return args != null && args.Length == (int)CountArgument.Necessary;
        }
    }
}
