using Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyVectorGraphicsEditor.Classes.Figures
{
    class CustomFigure : Figure
    {
        public  List<FigurePoint> Points { get; private set; }

        public CustomFigure(Figure f)
        {
            if (f.GetType() == typeof(Rectangle))
            {
                Points = new List<FigurePoint>();
                Points.Add(new FigurePoint(f.X, f.Y));
                Points.Add(new FigurePoint(f.X + f.Width, f.Y));
                Points.Add(new FigurePoint(f.X + f.Width, f.Y + f.Height));
                Points.Add(new FigurePoint(f.X, f.Y + f.Height));
            }

            Resize(f.Width, f.Height);
            Move(f.X, f.Y);
        }

        public override void Draw(Graphics graphics)
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                graphics.DrawLine(Pens.Black, Points[i].X, Points[i].Y, Points[i + 1].X, Points[i + 1].Y);
            }

            graphics.DrawLine(Pens.Black, Points[^1].X, Points[^1].Y, Points[0].X, Points[0].Y);
            Update();
            foreach (var point in Points)
            {
                point.Draw(graphics);
            }
        }

        public void Update()
        {
             var x = Points.Min(a => a.X);
             var y = Points.Min(a => a.Y);

             var xmax = Points.Max(a => a.X);
             var ymax = Points.Max(a => a.Y);

            Move(x,y);
            Resize(xmax - x, ymax - y);
        }
    }
}
