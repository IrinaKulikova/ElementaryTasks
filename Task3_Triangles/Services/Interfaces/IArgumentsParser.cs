using System.Collections.Generic;
using Task3_Triangles.Models;

namespace Task3_Triangles.Services.Interfaces
{
    public interface IArgumentsParser
    {
        List<IFigure> Figures(string[] args);
    }
}
