namespace Task4_Parser.UI
{
    public interface IManager
    {
        void ShowInstructon();
        void ShowCount(int count);
        void ShowReplacedText(string textResult);
        void InvalidInputArguments(string[] arguments);
    }
}
