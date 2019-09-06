using System.Collections.Generic;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories.Interfaces
{
    public interface INumberPartsCollectionFactory
    {
        Queue<NumberPart> Parse(string number);
    }
}
