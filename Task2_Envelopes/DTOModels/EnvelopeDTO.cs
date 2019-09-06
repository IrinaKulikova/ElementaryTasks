namespace Task2_Envelopes.DTOModels
{
    public class EnvelopeDTO
    {
        #region properties 

        public string Heigth { get; private set; }
        public string Width { get; private set; }

        #endregion

        public EnvelopeDTO(string heigth, string width)
        {
            Heigth = heigth;
            Width = width;
        }
    }
}
