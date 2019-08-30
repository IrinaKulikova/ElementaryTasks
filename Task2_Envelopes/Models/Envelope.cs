using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Models
{
    public class Envelope : IEnvelope
    {
        public float Height { get; private set; }
        public float Width { get; private set; }
        
        public Envelope(float height, float width)
        {
            Height = height;
            Width = width;
        }
    }
}
