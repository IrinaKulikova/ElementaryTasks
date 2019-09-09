using System.Collections.Generic;

namespace Task7_8_Sequence.UI
{
    public interface IManager
    {
        void ShowInstruction();
        void ShowResult(IEnumerable<int> sequence);
    }
}
