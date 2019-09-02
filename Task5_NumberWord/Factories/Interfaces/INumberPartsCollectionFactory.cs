using System.Collections.Generic;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories.Interfaces
{
    public interface INumberPartsCollectionFactory
    {
        List<NumberPart> Parse(string number);
    }
}
