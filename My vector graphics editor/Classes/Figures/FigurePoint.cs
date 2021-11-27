using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Figures;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    class FigurePoint: Figure
    {
        public FigurePoint(float x, float y)
        {
            Move(x, y);
            Resize(7,7);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.Black, X - 3, Y - 3, Width, Height);
        }
    }
}
