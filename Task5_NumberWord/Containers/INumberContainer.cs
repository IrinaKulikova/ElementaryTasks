using System.Collections;
using System.Collections.Generic;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Containers
{
    public interface INumberContainer : IEnumerable
    {
        Number this[int i] { get; }
        List<Number> PartsNumber { get; }
    }
}