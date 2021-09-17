using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    class Rectangle : Figure
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public override int Width { get; set; } = 10;
        public override int Height { get; set; } = 10;

        public override Figure Clone()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Black), X, Y, Width, Height);
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
