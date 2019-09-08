using System.Collections.Generic;

namespace Task3_Triangles.Models
{
    public class Triangle : IFigure
    {
        #region private fields

        private readonly List<float> _sides;
        private readonly float _square;
        private readonly string _name;

        #endregion

        #region properties

        public List<float> Sides { get => _sides;  }
        public float Square { get => _square; }
        public string Name { get => _name; }

        #endregion

        public Triangle(string name, IEnumerable<float> sides, float square)
        {
            _name = name;
            _sides = new List<float>(sides);
            _square = square;
        }
    }
}