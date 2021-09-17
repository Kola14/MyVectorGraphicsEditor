using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyVectorGraphicsEditor.Classes
{
    abstract class Figure
    {
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        public abstract void Draw(Graphics graphics);
        public abstract void Move();
        public abstract Figure Clone();
    }
}
