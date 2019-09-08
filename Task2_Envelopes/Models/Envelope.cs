using Task2_Envelopes.Models.Interfaces;

namespace Task2_Envelopes.Models
{
    public class Envelope : IEnvelope
    {
        #region private fields

        private readonly float _height;
        private readonly float _width;

        #endregion

        #region properties

        public float Height { get => _height; }
        public float Width { get => _width; }

        #endregion

        public Envelope(float height, float width)
        {
            _height = height;
            _width = width;
        }
    }
}
