using Task5_NumberWord.Factories.Interfaces;

namespace Task5_NumberWord.Dictionaries
{
    public class DictionaryWordsEU : AbstractDictionaryWords
    {
        public DictionaryWordsEU(INumberPartFactory factory) : base (factory)
        {
            //read from resoucers

            dictionaryNumbers.Add("0", "zero");
            dictionaryNumbers.Add("1", "one");
            dictionaryNumbers.Add("2", "two");
            dictionaryNumbers.Add("3", "three");
            dictionaryNumbers.Add("4", "four");
            dictionaryNumbers.Add("5", "five");
            dictionaryNumbers.Add("6", "six");
            dictionaryNumbers.Add("7", "seven");
            dictionaryNumbers.Add("8", "eight");
            dictionaryNumbers.Add("9", "nine");
            dictionaryNumbers.Add("10", "ten");
            dictionaryNumbers.Add("11", "eleven");
            dictionaryNumbers.Add("12", "twelve");
            dictionaryNumbers.Add("13", "thirteen");
            dictionaryNumbers.Add("14", "fourteen");
            dictionaryNumbers.Add("15", "fifteen");
            dictionaryNumbers.Add("16", "sixteen");
            dictionaryNumbers.Add("17", "seventeen");
            dictionaryNumbers.Add("18", "eighteen");
            dictionaryNumbers.Add("19", "nineteen");

            dictionaryTens.Add("2", "twenty");
            dictionaryTens.Add("3", "thirty");
            dictionaryTens.Add("4", "forty");
            dictionaryTens.Add("5", "fifty");
            dictionaryTens.Add("6", "sixty");
            dictionaryTens.Add("7", "seventy");
            dictionaryTens.Add("8", "eighty");
            dictionaryTens.Add("9", "ninety");

            dictionaryBits.Add(0, "hundred");
            dictionaryBits.Add(1, "thousand");
            dictionaryBits.Add(2, "million");
            dictionaryBits.Add(3, "billion");
        }
    }
}
