using System.Drawing;
using Figures;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class CustomHandler: Handler
    {
        public CustomHandler(Figure f) : base(f)
        {
            Move(f.X, f.Y);
            Resize(7, 7);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X - 3, Y - 3, 7, 7);
        }

        public override void Drag(float x, float y)
        {
            manipulator.Move(manipulator.X + x, manipulator.Y + y);
            Reposition();
        }

        public override void Reposition()
        {
            Move(manipulator.X, manipulator.Y);
            Resize(manipulator.Width, manipulator.Height);
        }

        public override bool Touch(float ax, float ay)
        {
            return base.Touch(ax, ay);
        }

        public override Handler PickNewHandler()
        {
            return this;
        }
    }
}
