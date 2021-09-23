using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MyVectorGraphicsEditor.Classes.Figures;

namespace MyVectorGraphicsEditor.Classes
{
    class Model
    {
        private List<Figure> figures = new List<Figure>();

        public void Add(Figure f)
        {
            if (f is null) return;
            if (figures.Contains(f)) return;

            figures.Add(f);
        }

        public void Draw(Graphics g)
        {
            foreach (var f in figures)
            {
                f.Draw(g);
            }
        }

        public Figure Select(int x, int y)
        {
            foreach (var f in figures)
            {
                if (f.Touch(x, y))
                {
                    return f;
                }
            }
            return null;
        }
    }
}
