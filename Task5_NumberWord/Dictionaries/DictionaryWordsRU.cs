using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Dictionaries
{
    public class DictionaryWordsRU : AbstractDictionaryWords
    {
        public DictionaryWordsRU(IDigitsFactory factory) : base(factory)
        {
            //read from resoucers

            //dictionaryNumbers.Add("0", "ноль");
            dictionaryNumbers.Add("1", "один");
            dictionaryNumbers.Add("2", "два");
            dictionaryNumbers.Add("3", "три");
            dictionaryNumbers.Add("4", "четыре");
            dictionaryNumbers.Add("5", "пять");
            dictionaryNumbers.Add("6", "шесть");
            dictionaryNumbers.Add("7", "семь");
            dictionaryNumbers.Add("8", "восем");
            dictionaryNumbers.Add("9", "девять");
            dictionaryNumbers.Add("10", "десять");
            dictionaryNumbers.Add("11", "одиннадцать");
            dictionaryNumbers.Add("12", "двенадцать");
            dictionaryNumbers.Add("13", "тринадцать");
            dictionaryNumbers.Add("14", "четырнадцать");
            dictionaryNumbers.Add("15", "пятнадцать");
            dictionaryNumbers.Add("16", "шестнадцать");
            dictionaryNumbers.Add("17", "семнадцать");
            dictionaryNumbers.Add("18", "восемнадцать");
            dictionaryNumbers.Add("19", "девятнадцать");

            dictionaryTens.Add("2", "двадцать");
            dictionaryTens.Add("3", "тридцать");
            dictionaryTens.Add("4", "сорок");
            dictionaryTens.Add("5", "пятдесят");
            dictionaryTens.Add("6", "шестдесят");
            dictionaryTens.Add("7", "семдесят");
            dictionaryTens.Add("8", "восемдесят");
            dictionaryTens.Add("9", "девяносто");

            dictionaryBits.Add(0, "сто");
            dictionaryBits.Add(1, "тясяча");
            dictionaryBits.Add(2, "миллион");
            dictionaryBits.Add(3, "миллиард");
        }
    }
}
