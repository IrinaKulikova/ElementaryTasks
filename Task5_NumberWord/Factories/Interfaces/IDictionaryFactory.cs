using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Enums;

namespace Task5_NumberWord.Factories
{
    public interface IManagerDictionary
    {
        AbstractDictionaryWords GetDictionary(Language language);
    }
}
