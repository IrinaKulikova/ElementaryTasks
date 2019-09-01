using System.Collections.Generic;

namespace Task5_NumberWord.UI
{
    public interface IManagerViews
    {
        void Instruction();
        void Result(List<string> numberWords);
    }
}
