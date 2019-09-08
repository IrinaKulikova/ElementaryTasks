using System.Collections.Generic;

namespace Task8_Fibonacci.UI
{
    public interface IManager
    {
        void ShowInstruction();
        void ShowResult(IEnumerable<int> sequence);
    }
}
