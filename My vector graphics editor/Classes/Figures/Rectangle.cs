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
        public override int Width { get; set; }
        public override int Height { get; set; }

        public override Figure Clone()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
