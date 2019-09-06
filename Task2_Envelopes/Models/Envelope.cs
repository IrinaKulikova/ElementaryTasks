using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Models
{
    public class Envelope : IEnvelope
    {
        #region properties

        public float Height { get; private set; }
        public float Width { get; private set; }

        #endregion

        public Envelope(float height, float width)
        {
            Height = height;
            Width = width;
        }
    }
}
