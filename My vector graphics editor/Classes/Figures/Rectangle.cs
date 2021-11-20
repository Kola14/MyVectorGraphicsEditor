using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Figures;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    class Rectangle : Figure
    {
        public override Figure Clone()
        {
            Rectangle r = new Rectangle();
            r.Resize(Width, Height);
            r.Move(X, Y);
            return r;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Black, X, Y, Width, Height);
        }
    }
}
