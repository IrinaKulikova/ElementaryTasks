using System.Collections.Generic;
using System.Linq;
using Task3_Triangles.Factories;
using Task3_Triangles.Models;
using Task3_Triangles.Services.Interfaces;

namespace Task3_Triangles.Services
{
    public class ArgumentsParser : IArgumentsParser
    {
        #region private fields

        private readonly IFigureFactory figureFactory = null;

        #endregion

        public ArgumentsParser(IFigureFactory figureFactory)
        {
            this.figureFactory = figureFactory;
        }

        public List<IFigure> Figures(string[] args)
        {
            int countSize = (int)figureFactory.CountSides;

            List<float> sides = new List<float>();
            List<string> names = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (i % (countSize + 1) != 0)
                {
                    if (float.TryParse(args[i], out float side))
                    {
                        sides.Add(side);
                    }
                }
                else
                {
                    names.Add(args[i]);
                }
            }

            var figures = new List<IFigure>();

            for (int i = 0, j = 0; i < sides.Count; i += countSize, j++)
            {
                IEnumerable<float> figureSides = sides.Skip(i).Take(countSize).ToList();
                IFigure figure = figureFactory.Create(names[j], figureSides);
                figures.Add(figure);
            }

            return figures;
        }
    }
}