using System.Collections.Generic;

namespace Task3_Triangles.Models
{
    public interface IFigure
    {
        string Name { get; }
        List<float> Sides { get; }
        float Square { get; }
    }
}
