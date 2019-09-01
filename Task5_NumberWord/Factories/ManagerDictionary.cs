using Task5_NumberWord.Dictionaries;
using Task5_NumberWord.Enums;
using Task5_NumberWord.Factories.Interfaces;

namespace Task5_NumberWord.Factories
{
    public class ManagerDictionary : IManagerDictionary
    {
        IDigitsFactory numberPartFactory = null;

        public ManagerDictionary(IDigitsFactory numberPartFactory)
        {
            this.numberPartFactory = numberPartFactory;
        }

        public AbstractDictionaryWords GetDictionary(Language language)
        {
            switch (language)
            {
                case Language.RU:
                    return new DictionaryWordsRU(numberPartFactory);

                case Language.EU:
                default:
                    return new DictionaryWordsEU(numberPartFactory);
            }
        }
    }
}
