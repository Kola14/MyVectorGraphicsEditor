using System;
using System.Collections.Generic;
using System.Text;

namespace MyVectorGraphicsEditor.Classes.Figures.Creators
{
    class EllipseCreator : FigureCreator
    {
        private static FigureCreator instance = null;

        private EllipseCreator() { }

        public static FigureCreator GetInstance()
        {
            if (instance is null) instance = new EllipseCreator();

            return instance;
        }

        public override Figure Create()
        {
            var e = new Ellipse();
            e.Resize(50, 50);
            return e;
        }
    }
}
