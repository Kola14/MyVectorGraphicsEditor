using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Figures;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    [Serializable]
    class Ellipse : Figure
    {
        public override Figure Clone()
        {
            Ellipse e = new Ellipse();
            e.Resize(Width, Height);
            e.Move(X, Y);
            return e;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(Pens.Black, X, Y, Width, Height);
        }
    }
}
