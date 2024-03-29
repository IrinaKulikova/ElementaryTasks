﻿using System.Collections.Generic;
using System.Linq;
using Task3_Triangles.Factories;
using Task3_Triangles.Models;
using Task3_Triangles.Services.Interfaces;

namespace Task3_Triangles.Services
{
    public class ArgumentsParser : IArgumentsParser
    {
        #region private fields

        private readonly IFigureFactory _figureFactory;

        #endregion

        public ArgumentsParser(IFigureFactory figureFactory)
        {
            _figureFactory = figureFactory;
        }

        public List<IFigure> Figures(string[] args)
        {
            int countSize = (int)_figureFactory.CountSides;

            var sides = new List<float>();
            var names = new List<string>();

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
                var figureSides = sides.Skip(i).Take(countSize).ToList();
                var figure = _figureFactory.Create(names[j], figureSides);
                figures.Add(figure);
            }

            return figures;
        }
    }
}