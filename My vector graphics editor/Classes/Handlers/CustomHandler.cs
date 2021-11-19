using System.Drawing;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class CustomHandler: Handler
    {
        public CustomHandler(Figure f) : base(f)
        {
            Resize(6, 6);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, 6, 6);
        }

        public override void Drag(float x, float y)
        {
            manipulator.Move(manipulator.X + x, manipulator.Y + y);
            Reposition();
        }

        public override void Reposition()
        {
            Move(manipulator.X, manipulator.Y);
        }
    }
}
