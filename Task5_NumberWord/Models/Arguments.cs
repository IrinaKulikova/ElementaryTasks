using Task5_NumberWord.Enums;

namespace Task5_NumberWord.Models
{
    public class Arguments
    {
        #region private fields

        private readonly string _number;
        private readonly Language _language;

        #endregion

        #region properties

        public string Number { get => _number; }
        public Language Language { get => _language; }

        #endregion

        public Arguments(string number, Language language)
        {
            _number = number;
            _language = language;
        }

        public Arguments(string number) : this(number, Language.EU) { }
    }
}
