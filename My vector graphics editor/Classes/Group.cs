using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyVectorGraphicsEditor.Classes
{
    class Group: Figure
    {
        private List<Figure> figures = new List<Figure>();

        public List<Figure> Figures => figures;

        public override void Draw(Graphics graphics)
        {
            foreach (var f in figures) 
                f.Draw(graphics);
        }

        public bool IsEmpty()
        {
            return figures.Count == 0;
        }

        public override void Resize(float newWidth, float newHeight)
        {
            var kx = newWidth / Width;
            var ky = newHeight / Height;
            foreach (var f in figures)
            {
                f.Resize(kx * f.Width, ky * f.Height);
                f.Move(X + kx*(f.X - X), Y + ky * (f.Y - Y));
            }

            base.Resize(newWidth, newHeight);
        }

        public override void Move(float ax, float ay)
        {
            var dx = ax - X;
            var dy = ay - Y;
            foreach (var f in figures)
                f.Move(f.X + dx, f.Y + dy);
            base.Move(ax, ay);
        }

        public override bool Touch(float ax, float ay)
        {
            foreach (var f in figures)
                if (f.Touch(ax, ay))
                    return true;
            return false;
        }

        public void Add(Figure f)
        {
            if (f is null) return;
            if (figures.Contains(f)) return;
            if (f == this) return;
            figures.Add(f);
            var xx = figures.Min(a => a.X);
            var yy = figures.Min(a => a.Y);
            var xx2 = figures.Max(a => a.X + a.Width);
            var yy2 = figures.Max(a => a.Y + a.Width);
            base.Move(xx, yy);
            base.Resize(xx2 - xx, yy2 - yy);
        }

        public override Figure Clone()
        {
            var clone = new Group();

            clone.Move(X, Y);
            clone.Resize(Width, Height);

            foreach (var f in figures)
                clone.Add(f.Clone());

            return clone;
        }
    }
}
