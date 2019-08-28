using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Models
{
    public class Envelope : IEnvelope
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        
        public Envelope(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
