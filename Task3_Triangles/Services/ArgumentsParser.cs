using System.Collections.Generic;
using System.Linq;
using Task3_Triangles.Factories;
using Task3_Triangles.Models;
using Task3_Triangles.Services.Interfaces;

namespace Task3_Triangles.Services
{
    public class ArgumentsParser : IArgumentsParser
    {
        IFigureFactory figureFactory = null;

        public ArgumentsParser(IFigureFactory figureFactory)
        {
            this.figureFactory = figureFactory;
        }

        public List<IFigure> Figures(string[] args)
        {
            int countSize = (int)figureFactory.CountSides;

            List<float> sides = new List<float>();

            for (int i = 0; i < args.Length; i++)
            {
                if (float.TryParse(args[i], out float side))
                {
                    sides.Add(side);
                }
            }

            var figures = new List<IFigure>();

            for (int i = 0; i < sides.Count; i += countSize)
            {
                IEnumerable<float> figureSides = sides.Skip(i).Take(countSize).ToList();
                IFigure figure = figureFactory.Create(figureSides);
                figures.Add(figure);
            }

            return figures;
        }
    }
}
