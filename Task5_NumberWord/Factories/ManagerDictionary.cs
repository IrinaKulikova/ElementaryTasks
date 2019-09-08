using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Enums;
using Task5_NumberWord.Factories.Interfaces;

namespace Task5_NumberWord.Factories
{
    public class ManagerDictionary : IManagerDictionary
    {
        IDigitsFactory digitsFactory = null;

        public ManagerDictionary(IDigitsFactory digitsFactory)
        {
            this.digitsFactory = digitsFactory;
        }

        public AbstractDictionaryWords GetDictionary(Language language)
        {
            switch (language)
            {
                case Language.RU:
                    return new DictionaryWordsRU(digitsFactory);

                case Language.EU:
                default:
                    return new DictionaryWordsEU(digitsFactory);
            }
        }
    }
}
