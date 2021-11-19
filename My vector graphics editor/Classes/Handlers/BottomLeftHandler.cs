using System;
using System.Drawing;

namespace MyVectorGraphicsEditor.Classes.Handlers
{
    class BottomLeftHandler : Handler
    {
        public BottomLeftHandler(Figure f) : base(f)
        {
            Resize(6, 6);
            Move(f.X - 3, f.Y + f.Height - 3);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Red, X, Y, Width, Height);
        }

        public override void Drag(float x, float y)
        {
            manipulator.Move(manipulator.X + x, manipulator.Y);
            manipulator.Resize(manipulator.Width - x, manipulator.Height + y);
            Reposition();
        }

        public override void Reposition()
        {
            Move(manipulator.X - 3, manipulator.Y + manipulator.Height - 3);
        }

        public override Handler PickNewHandler()
        {
            var width = manipulator.Width;
            var height = manipulator.Height;
            var x = manipulator.X;
            var y = manipulator.Y;

            if (width < 0 && height < 0)
            {
                manipulator.Move(x + width, y + height);
                //ActivePoint = 3;

                manipulator.Resize(Math.Abs(width) + 10, Math.Abs(height) + 10);

                return new BottomRightHandler(manipulator);
            }

            if (width < 0)
            {
                //ActivePoint = 3;
                manipulator.Move(x + width, y);

                manipulator.Resize(Math.Abs(width) + 10, height);

                return new BottomRightHandler(manipulator);
            }

            if (height < 0)
            {
                //ActivePoint = 1;
                manipulator.Move(x, y + height);

                manipulator.Resize(width, Math.Abs(height) + 10);

                return new TopLeftHandler(manipulator);
            }

            return new BottomLeftHandler(manipulator);
        }
    }
}
