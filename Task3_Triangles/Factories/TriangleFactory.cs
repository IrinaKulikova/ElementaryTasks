using System;
using System.Collections.Generic;
using Task3_Triangles.Enums;
using Task3_Triangles.Models;

namespace Task3_Triangles.Factories
{
    public class TriangleFactory : IFigureFactory
    {

        public ValidCountArguments CountSides
        {
            get => ValidCountArguments.Triangle - 1;
        }

        public IFigure Create(string name, IEnumerable<float> sides)
        {
            float perimeter = 0;

            foreach (var side in sides)
            {
                perimeter += side;
            }

            var halfPerimeter = perimeter / 2;

            float multys = 1;

            foreach (var side in sides)
            {
                multys *= (halfPerimeter - side);
            }

            var square = Math.Sqrt(halfPerimeter * multys);

            return new Triangle(name, sides, (float)square);
        }
    }
}