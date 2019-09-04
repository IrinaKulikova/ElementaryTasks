using System;
using System.Collections.Generic;
using System.Linq;
using Task3_Triangles.Enums;
using Task3_Triangles.Models;

namespace Task3_Triangles.Factories
{
    public class TriangleFactory : IFigureFactory
    {
        public ValidCountArguments CountSides => ValidCountArguments.CountTriangleSide;

        public IFigure Create(IEnumerable<float> sides)
        {
            float perimeter = 0;
            foreach (var side in sides)
            {
                perimeter += side;
            }

            var halfPerimeter = perimeter / 2;

            float multys = 1;

            sides.ToList().ForEach(s => multys *= (halfPerimeter - s));
            var square = Math.Sqrt(halfPerimeter * multys);

            return new Triangle(sides, (float)square);
        }
    }
}