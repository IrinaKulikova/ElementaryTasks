using System;
using System.Collections.Generic;
using Task2_Envelopes.DTOModels;
using Task2_Envelopes.Enums;

namespace Task2_Envelopes.UI
{
    public class ConsoleManager : IManager
    {
        public EnvelopeDTO GetParametersEnvelopes()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Height: ");
            var height = Console.ReadLine().Replace('.', ',');
            Console.Write("Width: ");
            var width = Console.ReadLine().Replace('.', ',');

            return new EnvelopeDTO(height, width);
        }


        public Answer ReadAnswerContinue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Do You want to continue?");
            var answer = Console.ReadLine();

            var trueAnswers = new List<string>() { "y", "yes" };

            return trueAnswers.Contains(answer.ToLower()) ? Answer.Yes : Answer.No;
        }


        public void ShowError(EnvelopeDTO envelopeDTO)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Arguments are invalid:");
            Console.WriteLine("Heigth is " + envelopeDTO.Heigth);
            Console.WriteLine("Width is " + envelopeDTO.Width);

            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void ShowInstruction()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You should enter four <float> parameters!");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void WriteResult(ResultEnvelopeCompare compareResult)
        {
            switch (compareResult)
            {
                case ResultEnvelopeCompare.FistBigger:
                    Console.WriteLine("The first envelope is bigger! Put the second into the first one.");
                    break;

                case ResultEnvelopeCompare.SecondBigger:
                    Console.WriteLine("The second envelope is bigger! Put the first into the second one.");
                    break;

                case ResultEnvelopeCompare.Equales:
                    Console.WriteLine("Envelopes are equal.");
                    break;

                case ResultEnvelopeCompare.NoFit:
                    Console.WriteLine("Envelopes do not fit.");
                    break;

                case ResultEnvelopeCompare.NoCompared:
                default:
                    Console.WriteLine("Strange result... It cann't be!");
                    break;
            }

            Console.ReadKey();
        }
    }
}
