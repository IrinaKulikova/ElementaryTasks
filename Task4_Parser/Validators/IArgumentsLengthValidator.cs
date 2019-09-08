namespace Task4_Parser.Validators
{
    public interface IArgumentsLengthValidator
    {
        bool HasValidLength(string[] arguments);
        bool HasNullArguments(string[] arguments);
    }
}
