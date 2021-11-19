using System.Collections.Generic;
using System.Drawing;
using MyVectorGraphicsEditor.Classes.Figures;
using MyVectorGraphicsEditor.Classes.Handlers;

namespace MyVectorGraphicsEditor.Classes
{
    class CustomSupermanipulator: SuperManipulator
    {
        private List<FigurePoint> points = new List<FigurePoint>();

        public CustomSupermanipulator(Model model, Figure f)
        {
            points = new List<FigurePoint>();
            points.Add(new FigurePoint(f.X, f.Y));
            points.Add(new FigurePoint(f.X + f.Width, f.Y));
            points.Add(new FigurePoint(f.X + f.Width, f.Y + f.Height));
            points.Add(new FigurePoint(f.X, f.Y + f.Height));

            foreach (var point in points)
            {
                handlers.Add(new CustomHandler(point));
            }
            model.Add(this);
        }

        public override void Draw(Graphics graphics)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                graphics.DrawLine(Pens.Black, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            }

            graphics.DrawLine(Pens.Black, points[^1].X, points[^1].Y, points[0].X, points[0].Y);

            foreach (var handler in handlers)
            {
                handler.Draw(graphics);
            }
        }

        public override void Attach(Figure f)
        {
            points = new List<FigurePoint>();
            points.Add(new FigurePoint(f.X, f.Y));
            points.Add(new FigurePoint(f.X + f.Width, f.Y));
            points.Add(new FigurePoint(f.X + f.Width, f.Y + f.Height));
            points.Add(new FigurePoint(f.X, f.Y + f.Height));

            foreach (var point in points)
            {
                handlers.Add(new CustomHandler(point));
            }
        }
    }
}
