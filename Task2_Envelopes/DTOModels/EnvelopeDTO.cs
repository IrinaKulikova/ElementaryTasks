namespace Task2_Envelopes.DTOModels
{
    public class EnvelopeDTO
    {
        public string Heigth { get; private set; }
        public string Width { get; private set; }

        public EnvelopeDTO(string heigth, string width)
        {
            Heigth = heigth;
            Width = width;
        }
    }
}
