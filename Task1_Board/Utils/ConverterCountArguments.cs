using Task1_Board.Utils.Interfaces;
using Task1_Board.Enums;

namespace Task1_Board.Utils
{
    public class ConverterCountArguments : IConverterCountArgument
    {
        public CountArgument GetValue(int? count)
        {
            var countArumentResult = CountArgument.Default;

            if (count.HasValue)
            {
                if (count == 0)
                {
                    countArumentResult = CountArgument.Zero;
                }

                if (count == 2)
                {
                    countArumentResult = CountArgument.Necessary;
                }
            }

            return countArumentResult;
        }
    }
}
