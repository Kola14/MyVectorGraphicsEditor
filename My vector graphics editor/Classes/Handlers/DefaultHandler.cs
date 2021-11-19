using System.Drawing;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class DefaultHandler : Handler
    {
        public DefaultHandler(Figure f) : base(f)
        {
            Resize(f.Width, f.Height);
            Move(f.X, f.Y);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X + Width / 2 - 3, Y + Height / 2 - 3, 6, 6);
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

        public override Handler PickNewHandler()
        {
            return new DefaultHandler(manipulator);
        }
    }
}


