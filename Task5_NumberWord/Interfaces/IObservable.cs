using Task5_NumberWord.UI;

namespace Task5_NumberWord.Interfaces
{
    public interface IObservable
    {
        void AddObserver(IManagerViews m);
        void NotifyShowInstruction();
        void NotifyShowNumberWords(string words);
    }
}
