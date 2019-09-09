namespace Task7_8_Sequence.Validators
{
    public class ArgumentsNotNullValidator : IValidator
    {
        public bool IsValid(string[] arguments)
        {
            return arguments != null && arguments.Length != 0;
        }
    }
}
