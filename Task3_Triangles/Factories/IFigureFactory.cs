using System.Collections.Generic;
using Task3_Triangles.Enums;
using Task3_Triangles.Models;

namespace Task3_Triangles.Factories
{
    public interface IFigureFactory
    {
        ValidCountArguments CountSides { get; }
        IFigure Create(IEnumerable<float> sides);
    }
}