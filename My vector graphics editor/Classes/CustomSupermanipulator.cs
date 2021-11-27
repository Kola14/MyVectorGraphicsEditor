using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Figures;
using MyVectorGraphicsEditor.Classes.Figures;
using MyVectorGraphicsEditor.Classes.Handlers;

namespace MyVectorGraphicsEditor.Classes
{
    class CustomSuperManipulator: SuperManipulator
    {
        private CustomFigure figure { get; set; }

        public override void Attach(Figure f)
        {
            var custom = (CustomFigure) f;
            figure = custom;

            Resize(figure.Width, figure.Height);
            Move(figure.X, figure.Y);

            foreach (var point in custom.Points)
            {
                handlers.Add(new CustomHandler(point));
            }
        }

        public override void Draw(Graphics graphics)
        {
            figure.Draw(graphics);

            //graphics.DrawRectangle(Pens.Green, X, Y, Width, Height);
            ActiveHandler?.Draw(graphics);
        }

        //public override bool Touch(float ax, float ay)
        //{
        //    //return ax >= figure.Points.Min(a => a.X) && ax <= figure.Points.Max(a => a.X) &&
        //    //       ay >= figure.Points.Min(a => a.Y) && ay <= figure.Points.Max(a => a.Y);

        //    foreach (var point in figure.Points.Where(point => point.Touch(ax, ay)))
        //    {
        //        Selected = point;
        //        ActiveHandler = new CustomHandler(Selected);
        //        return true;
        //    }

        //    return false;
        //}

        public override void Update()
        {
            if (Selected is null) return;
            Selected.Move(X, Y);

            figure.Update();
            Move(figure.X - 10, figure.Y - 10);
            Resize(figure.Width + 20, figure.Height + 20);
        }
    }
}
