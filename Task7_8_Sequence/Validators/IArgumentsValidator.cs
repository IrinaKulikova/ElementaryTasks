namespace Task8_Fibonacci.Validators
{
    public interface IArgumentsValidator
    {
        bool HasNumbers(string[] args);

        bool HasTwoArguments(string[] args);
    }
}