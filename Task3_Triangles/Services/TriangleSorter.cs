using System.Collections.Generic;
using Task3_Triangles.Models;

namespace Task3_Triangles.Services
{
    public class TriangleSorter : IComparer<IFigure>
    {
        public int Compare(IFigure triangle1, IFigure triangle2)
        {

            if (triangle1.Square > triangle2.Square)
            {
                return -1;
            }

            if (triangle1.Square < triangle2.Square)
            {
                return 1;
            }

            return 0;
        }
    }
}