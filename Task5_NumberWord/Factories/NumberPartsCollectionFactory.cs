using System.Collections.Generic;
using Task5_NumberWord.Factories.Interfaces;
using Task5_NumberWord.Models;

namespace Task5_NumberWord.Factories
{
    public class NumberPartsCollectionFactory : INumberPartsCollectionFactory
    {
        public Queue<NumberPart> Parse(string number)
        {
            var partsNumber = new Queue<NumberPart>();

            int particleSize = 3;
            int higher = number.Length % particleSize;
            int capacity = number.Length / particleSize;
            int counter = 0;
            int position = 0;

            if (higher > 0)
            {
                capacity++;
                AddPart(number, higher, capacity, ref counter, ref position, partsNumber);
            }

            do
            {
                AddPart(number, particleSize, capacity, ref counter, ref position, partsNumber);

            } while (position < number.Length);

            return partsNumber;
        }

        private void AddPart(string number, int particleSize, int capacity, ref int counter, ref int position, Queue<NumberPart> partsNumber)
        {
            var part = new NumberPart()
            {
                Value = number.Substring(position, particleSize),
                Position = capacity - counter - 1
            };

            position += particleSize;
            counter++;
            partsNumber.Enqueue(part);
        }
    }
}