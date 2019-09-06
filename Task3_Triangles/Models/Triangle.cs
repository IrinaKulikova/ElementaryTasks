using System.Collections.Generic;

namespace Task3_Triangles.Models
{
    public class Triangle : IFigure
    {
        #region properties

        public List<float> Sides { get; private set; }
        public float Square { get; private set; }
        public string Name { get; private set; }

        #endregion

        public Triangle(string name, IEnumerable<float> sides, float square)
        {
            Name = name;
            Sides = new List<float>(sides);
            Square = square;
        }
    }
}