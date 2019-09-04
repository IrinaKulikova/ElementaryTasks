using System.Collections.Generic;

namespace Task3_Triangles.Models
{
    public class Triangle : IFigure
    {
        public List<float> Sides { get; private set; }
        public float Square { get; private set; }

        public Triangle(IEnumerable<float> sides, float square)
        {
            Sides = new List<float>(sides);
            Square = square;
        }
    }
}