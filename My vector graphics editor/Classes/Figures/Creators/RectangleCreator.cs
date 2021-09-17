using System;
using System.Collections.Generic;
using System.Text;

namespace MyVectorGraphicsEditor.Classes.Figures.Creators
{
    class RectangleCreator : FigureCreator
    {
        private static FigureCreator instance = null;

        private RectangleCreator() { }

        public static FigureCreator GetInstance()
        {
            if (instance is null) instance = new RectangleCreator();

            return instance;
        }

        public override Figure Create() => new Rectangle();
    }
}
