namespace Task4_Parser.UI
{
    public interface IManager
    {
        void ShowInstructon();
        void ShowCount(int count);
        void ShowReplacedDone();
        void InvalidInputArguments(string[] arguments);
    }
}
